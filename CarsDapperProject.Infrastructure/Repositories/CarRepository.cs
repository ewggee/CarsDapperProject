using CarsDapperProject.DataAccess.Dapper;
using CarsDapperProject.Domain.Entities;
using CarsDapperProject.Domain.Repositories;
using Dapper;

namespace CarsDapperProject.DataAccess.Repositories;

public class CarRepository : BaseRepository<Car>, ICarRepository
{
    private readonly DapperContext _context;

    public CarRepository(DapperContext context)
    {
        _context = context;
    }

    public async override Task<Car?> GetByIdAsync(int id)
    {
        var query = $@"
            SELECT 
            id as {nameof(Car.Id)},
            model as {nameof(Car.Model)},
            brand_id as {nameof(Car.BrandId)},
            owner_id as {nameof(Car.OwnerId)}
            FROM cars 
            WHERE id = @id";

        using var connection = _context.CreateConnection();

        var car = await connection.QueryFirstOrDefaultAsync<Car>(
            query,
            new { Id = id });

        return car;
    }

    public async override Task<int> AddAsync(Car entity)
    {
        var query = $@"
            INSERT INTO 
            cars (model, brand_id, owner_id) 
            VALUES
            (@model, @brand_id, @owner_id)
            RETURNING id";

        using var connection = _context.CreateConnection();

        var id = await connection.QueryFirstAsync<int>(
            query,
            new { model = entity.Model, brand_id = entity.BrandId, owner_id = entity.OwnerId });

        return id;
    }
}
