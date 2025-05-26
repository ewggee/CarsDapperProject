using CarsDapperProject.Application.Mappers;
using CarsDapperProject.Contracts.DTOs;
using CarsDapperProject.Contracts.DTOs.Requests.Brand;
using CarsDapperProject.Contracts.Services;
using CarsDapperProject.Domain.Exceptions.Brand;
using CarsDapperProject.Domain.Repositories;

namespace CarsDapperProject.Application.Services;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;

    public BrandService(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<BrandDto> GetBrandByIdAsync(int id)
    {
        var brand = await _brandRepository.GetByIdAsync(id) 
            ?? throw new BrandNotFoundException(id);

        return brand.MapToDto();
    }

    public async Task<IReadOnlyList<BrandDto>> GetAllBrandsAsync()
    {
        var brands = await _brandRepository.GetAllAsync();

        return brands.Select(b => b.MapToDto()).ToList().AsReadOnly();
    }

    public async Task<int> AddBrandAsync(CreateBrandRequest createBrandRequest)
    {
        var brandId = await _brandRepository.AddAsync(createBrandRequest.MapToEntity());

        return brandId;
    }

    public async Task UpdateBrandAsync(int id, UpdateBrandRequest updateBrandRequest)
    {
        var brand = updateBrandRequest.MapToEntity();
        brand.Id = id;

        await _brandRepository.UpdateAsync(brand);
    }

    public async Task DeleteBrandAsync(int id)
    {
        var deletedRows = await _brandRepository.DeleteAsync(id);
     
        if (deletedRows == 0) 
            throw new BrandNotFoundException(id);
    }
}
