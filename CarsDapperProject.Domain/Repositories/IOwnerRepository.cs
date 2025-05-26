using CarsDapperProject.Domain.Entities;

namespace CarsDapperProject.Domain.Repositories;

public interface IOwnerRepository
{
    Task<Owner?> GetByIdAsync(int id);
    Task<IEnumerable<Owner>> GetAllAsync();
    Task<int> AddAsync(Owner owner);
    Task UpdateAsync(Owner owner);
    /// <summary>
    /// Удаляет запись по <paramref name="id"/> и возвращает количество затронутых записей.
    /// </summary>
    /// <returns>
    /// Количество удалённых записей.
    /// </returns>
    Task<int> DeleteAsync(int id);
    Task<bool> IsOwnerByIdExistsAsync(int id);
}
