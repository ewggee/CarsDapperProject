using CarsDapperProject.Application.Abstractions;
using CarsDapperProject.Application.DTOs;
using CarsDapperProject.Application.Extensions;

namespace CarsDapperProject.Application.Services;

public class BrandService
{
    private readonly IBrandRepository _brandRepository;

    public BrandService(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<BrandDto> GetBrandByIdAsync(int id)
    {
        var brand = await _brandRepository.GetByIdAsync(id);
        //TODO: выброс исключения при отсутствии бренда

        return brand.MapToDto();
    }

    public async Task<IReadOnlyList<BrandDto>> GetAllBrandsAsync()
    {
        var brands = await _brandRepository.GetAllAsync();

        return brands.Select(b => b.MapToDto()).ToList().AsReadOnly();
    }

    public async Task<int> AddBrandAsync(BrandRequest createBrandRequest)
    {
        var brandId = await _brandRepository.AddAsync(createBrandRequest.MapToEntity());

        return brandId;
    }

    public async Task UpdateBrandAsync(int id, BrandRequest brandRequest)
    {
        var brand = brandRequest.MapToEntity();
        brand.Id = id;

        await _brandRepository.UpdateAsync(brand);
    }

    public async Task DeleteBrandAsync(int id)
    {
        await _brandRepository.DeleteAsync(id);
    }
}
