using CarsDapperProject.Application.Mappers;
using CarsDapperProject.Contracts.DTOs;
using CarsDapperProject.Contracts.Requests.Car;
using CarsDapperProject.Domain.Exceptions.Brand;
using CarsDapperProject.Domain.Exceptions.Car;
using CarsDapperProject.Domain.Repositories;

namespace CarsDapperProject.Application.Services;

public class CarService
{
    private readonly ICarRepository _carRepository;
    private readonly IBrandRepository _brandRepository;

    public CarService(
        ICarRepository carRepository, 
        IBrandRepository brandRepository)
    {
        _carRepository = carRepository;
        _brandRepository = brandRepository;
    }

    public async Task<CarDto> GetCarByIdAsync(int id)
    {
        var car = await _carRepository.GetByIdAsync(id)
            ?? throw new CarNotFoundException(id);

        return car.MapToDto();
    }

    public async Task<IEnumerable<CarDto>> GetAllCarsAsync(int brandId)
    {
        var cars = await _carRepository.GetAllCarsByBrandAsync(brandId);

        return cars.Select(c => c.MapToDto());
    }

    public async Task<int> AddCarAsync(CreateCarRequest createCarRequest)
    {
        var isBrandExists = await _brandRepository.IsBrandExistsAsync(createCarRequest.BrandId);
        if (!isBrandExists) 
            throw new BrandNotFoundException(createCarRequest.BrandId);

        //TODO: is owner exists

        var id = await _carRepository.AddAsync(createCarRequest.MapToEntity());

        return id;
    }

    public async Task UpdateCarAsync(int id, UpdateCarRequest updateCarRequest)
    {
        var isBrandExists = await _brandRepository.IsBrandExistsAsync(updateCarRequest.BrandId);
        if (!isBrandExists)
            throw new BrandNotFoundException(updateCarRequest.BrandId);

        //TODO: is owner exists

        var car = updateCarRequest.MapToEntity();
        car.Id = id;

        await _carRepository.UpdateAsync(car);
    }

    public async Task DeleteCarAsync(int id)
    {
        var deletedRows = await _carRepository.DeleteAsync(id);

        if (deletedRows == 0)
            throw new CarNotFoundException(id);
    }
}
