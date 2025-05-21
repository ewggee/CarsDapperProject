using CarsDapperProject.Domain.Entities;
using CarsDapperProject.Domain.Repositories;
using Dapper;

namespace CarsDapperProject.Infrastructure.DataAccess.Repositories;

public class BrandRepository : BaseRepository<Brand>, IBrandRepository
{
    private readonly DapperContext _context;

    public BrandRepository(DapperContext context)
    {
        _context = context;
    }

    public override async Task<Brand?> GetByIdAsync(int id)
    {
        var query = $@"
            SELECT 
            id as {nameof(Brand.Id)}, 
            name as {nameof(Brand.Name)} 
            FROM brands 
            WHERE id = @id";

        using var connection = _context.CreateConnection();

        var brand = await connection.QueryFirstOrDefaultAsync<Brand>(
            query, 
            new { Id = id });

        return brand;
    }

    public override async Task<IReadOnlyList<Brand>> GetAllAsync()
    {
        var query = $@"
            SELECT 
            id as {nameof(Brand.Id)}, 
            name as {nameof(Brand.Name)} 
            FROM brands 
            WHERE id = @id";

        using var connection = _context.CreateConnection();

        var brands = await connection.QueryAsync<Brand>(query);

        return brands.ToList().AsReadOnly();
    }

    public override async Task<int> AddAsync(Brand entity)
    {
        var query = $@"
            INSERT INTO 
            brands (name) 
            VALUES
            (@name)
            RETURNING id";

        using var connection = _context.CreateConnection();

        var id = await connection.QueryFirstAsync<int>(
            query,
            new { name = entity.Name} );

        return id;
    }

    public override async Task UpdateAsync(Brand entity)
    {
        var query = $@"
            UPDATE brands
            SET
            name = coalesce(@name, name)
            WHERE id = @id";

        using var connection = _context.CreateConnection();

        await connection.ExecuteAsync(
            query,
            new { name = entity.Name, id = entity.Id });
    }

    public new async Task<int> DeleteAsync(int id)
    {
        var query = $@"
                DELETE FROM brands 
                WHERE id = @id";

        using var connection = _context.CreateConnection();

        var rowsAffected = await connection.ExecuteAsync(
            query,
            new { id = id });

        return rowsAffected;
    }
}
