using CarsDapperProject.DataAccess.Dapper;
using CarsDapperProject.DataAccess.Scripts;
using CarsDapperProject.Domain.Entities;
using CarsDapperProject.Domain.QueryModels.Car;
using CarsDapperProject.Domain.Repositories;

namespace CarsDapperProject.DataAccess.Repositories;

public class CarRepository : ICarRepository
{
    private readonly IDapperContext _context;

    public CarRepository(IDapperContext context)
    {
        _context = context;
    }

    public async Task<int> AddAsync(Car car)
    {
        var id = await _context.ExecuteWithResult<int>(new QueryObject(
            Sql.AddCar,
            new { model = car.Model, brand_id = car.BrandId, owner_id = car.OwnerId }));

        return id;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var affectedRows = await _context.Execute(new QueryObject(
            Sql.DeleteCar,
            new { id = id }));

        return affectedRows;
    }

    public async Task<IEnumerable<CarWithOwner>> GetAllCarsByBrandAsync(int brandId)
    {
        var cars = await _context.ListOrEmpty<CarWithOwner>(new QueryObject(
            Sql.GetAllCarsByBrand,
            new { brand_id = brandId}));

        return cars;
    }

    public async Task<IEnumerable<CarWithBrand>> GetAllCarsByOwnerAsync(int ownerId)
    {
        var cars = await _context.ListOrEmpty<CarWithBrand>(new QueryObject(
            Sql.GetAllCarsByOwner,
            new { owner_id = ownerId }));

        return cars;
    }

    public async Task<CarWithOwner?> GetByIdAsync(int id)
    {
        var car = await _context.FirstOrDefault<CarWithOwner>(new QueryObject(
            Sql.GetCarById,
            new { id = id }));

        return car;
    }

    public async Task UpdateAsync(Car car)
    {
        await _context.Execute(new QueryObject(
            Sql.UpdateCar,
            new { id = car.Id, model = car.Model, brand_id = car.BrandId, owner_id = car.OwnerId }));
    }
}
