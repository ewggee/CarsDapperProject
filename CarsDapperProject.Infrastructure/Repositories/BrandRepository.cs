using CarsDapperProject.DataAccess.Dapper;
using CarsDapperProject.DataAccess.Scripts;
using CarsDapperProject.Domain.Entities;
using CarsDapperProject.Domain.Repositories;

namespace CarsDapperProject.DataAccess.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly IDapperContext _context;

    public BrandRepository(IDapperContext context)
    {
        _context = context;
    }

    public async Task<Brand?> GetByIdAsync(int id)
    {
        var brand = await _context.FirstOrDefault<Brand>(new QueryObject(
            Sql.GetBrandById,
            new { Id = id }));

        return brand;
    }

    public async Task<IEnumerable<Brand>> GetAllAsync()
    {
        var brands = await _context.ListOrEmpty<Brand>(new QueryObject(
            Sql.GetAllBrands,
            new { }));

        return brands;
    }

    public async Task<int> AddAsync(Brand entity)
    {
        var id = await _context.ExecuteWithResult<int>(new QueryObject(
            Sql.AddBrand,
            new { name = entity.Name }));

        return id;
    }

    public async Task UpdateAsync(Brand entity)
    {
        await _context.Execute(new QueryObject(
            Sql.UpdateBrand,
            new { name = entity.Name, id = entity.Id }));
    }

    public async Task<int> DeleteAsync(int id)
    {
        var rowsAffected = await _context.Execute(new QueryObject(
            Sql.DeleteBrand,
            new { id }));

        return rowsAffected;
    }

    public async Task<bool> IsBrandExistsAsync(int id)
    {
        return await _context.ExecuteWithResult<bool>(new QueryObject(
            Sql.IsBrandByIdExists,
            new { id = id }));
    }
}
