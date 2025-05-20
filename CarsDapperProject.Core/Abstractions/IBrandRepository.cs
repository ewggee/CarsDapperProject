using CarsDapperProject.Domain.Entities;

namespace CarsDapperProject.Application.Abstractions;

public interface IBrandRepository : IRepository<Brand>
{
    /// <summary>
    /// Удаляет запись по <paramref name="id"/> и возвращает количество затронутых записей.
    /// </summary>
    /// <returns>
    /// Количество удалённых записей.
    /// </returns>
    new Task<int> DeleteAsync(int id);
}
