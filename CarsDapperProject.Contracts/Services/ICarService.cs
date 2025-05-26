using CarsDapperProject.Contracts.DTOs;
using CarsDapperProject.Contracts.DTOs.Requests.Car;

namespace CarsDapperProject.Application.Services;
public interface ICarService
{
    Task<int> AddCarAsync(CreateCarRequest createCarRequest);
    Task DeleteCarAsync(int id);
    Task<IEnumerable<CarDto>> GetAllCarsAsync(int brandId);
    Task<CarDto> GetCarByIdAsync(int id);
    Task UpdateCarAsync(int id, UpdateCarRequest updateCarRequest);
}