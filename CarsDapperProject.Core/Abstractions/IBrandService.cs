using CarsDapperProject.Application.DTOs;

namespace CarsDapperProject.Application.Abstractions;
public interface IBrandService
{
    Task<int> AddBrandAsync(CreateBrandRequest createBrandRequest);
    Task DeleteBrandAsync(int id);
    Task<IReadOnlyList<BrandDto>> GetAllBrandsAsync();
    Task<BrandDto> GetBrandByIdAsync(int id);
    Task UpdateBrandAsync(int id, UpdateBrandRequest updateBrandRequest);
}