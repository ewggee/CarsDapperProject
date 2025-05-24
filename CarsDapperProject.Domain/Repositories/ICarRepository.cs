using CarsDapperProject.Domain.Entities;
using CarsDapperProject.Domain.QueryModels.Car;

namespace CarsDapperProject.Domain.Repositories;

public interface ICarRepository
{
    Task<CarWithOwner?> GetByIdAsync(int id);
    Task<IEnumerable<CarWithOwner>> GetAllCarsByBrandAsync(int brandId);
    Task<int> AddAsync(Car car);
    Task UpdateAsync(Car car);
    /// <summary>
    /// Удаляет запись по <paramref name="id"/> и возвращает количество затронутых записей.
    /// </summary>
    /// <returns>
    /// Количество удалённых записей.
    /// </returns>
    Task<int> DeleteAsync(int id);
}
