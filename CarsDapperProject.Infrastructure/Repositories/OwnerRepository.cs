using CarsDapperProject.DataAccess.Dapper;
using CarsDapperProject.DataAccess.Scripts;
using CarsDapperProject.Domain.Entities;
using CarsDapperProject.Domain.Repositories;

namespace CarsDapperProject.DataAccess.Repositories;

public class OwnerRepository : IOwnerRepository
{
    private readonly IDapperContext _context;

    public OwnerRepository(IDapperContext context)
    {
        _context = context;
    }

    public async Task<Owner?> GetByIdAsync(int id)
    {
        var owner = await _context.FirstOrDefault<Owner>(new QueryObject(
            Sql.GetOwnerWithCarById,
            new { id = id }));

        return owner;
    }

    public async Task<IEnumerable<Owner>> GetAllAsync()
    {
        var owners = await _context.ListOrEmpty<Owner>(new QueryObject(
           Sql.GetAllOwners,
           new { }));

        return owners;
    }

    public async Task<int> AddAsync(Owner owner)
    {
        var id = await _context.ExecuteWithResult<int>(new QueryObject(
           Sql.AddOwner,
           new { name = owner.Name, phone = owner.Phone, email = owner.Email }));

        return id;
    }

    public async Task UpdateAsync(Owner owner)
    {
        await _context.Execute(new QueryObject(
           Sql.UpdateOwner,
           new { id = owner.Id, name = owner.Name, phone = owner.Phone, email = owner.Email }));
    }

    public async Task<int> DeleteAsync(int id)
    {
        //TODO: удаление машин с привязанным владельцем
        var affectedRows = await _context.Execute(new QueryObject(
           Sql.DeleteOwner,
           new { id = id }));

        return affectedRows;
    }

    public async Task<bool> IsOwnerByIdExistsAsync(int id)
    {
        return await _context.ExecuteWithResult<bool>(new QueryObject(
            Sql.IsOwnerByIdExists,
            new { id = id }));
    }
}
