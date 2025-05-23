using CarsDapperProject.Domain.Entities;

namespace CarsDapperProject.Domain.Repositories;

public interface IBrandRepository
{
    Task<Brand?> GetByIdAsync(int id);
    Task<IEnumerable<Brand>> GetAllAsync();
    Task<int> AddAsync(Brand brand);
    Task UpdateAsync(Brand brand);
    /// <summary>
    /// Удаляет запись по <paramref name="id"/> и возвращает количество затронутых записей.
    /// </summary>
    /// <returns>
    /// Количество удалённых записей.
    /// </returns>
    Task<int> DeleteAsync(int id);
}
