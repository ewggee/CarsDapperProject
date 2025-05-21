using CarsDapperProject.Contracts.DTOs;

namespace CarsDapperProject.Contracts.Services;
public interface IBrandService
{
    Task<int> AddBrandAsync(CreateBrandRequest createBrandRequest);
    Task DeleteBrandAsync(int id);
    Task<IReadOnlyList<BrandDto>> GetAllBrandsAsync();
    Task<BrandDto> GetBrandByIdAsync(int id);
    Task UpdateBrandAsync(int id, UpdateBrandRequest updateBrandRequest);
}