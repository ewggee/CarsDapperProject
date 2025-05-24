using CarsDapperProject.Application.Services;
using CarsDapperProject.Contracts.Requests.Car;
using CarsDapperProject.WebAPI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CarsDapperProject.WebAPI.Controllers;

[Route("api/cars")]
[ApiController]
[TypeFilter<ApiExceptionFilter>]
public class CarController : ControllerBase
{
    private readonly CarService _carService;

    public CarController(CarService carService)
    {
        _carService = carService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCarById([FromRoute] int id)
    {
        var car = await _carService.GetCarByIdAsync(id);

        return Ok(car);
    }

    [HttpGet("brand/{brandId}")]
    public async Task<IActionResult> GetAllCarsByBrand([FromRoute] int brandId)
    {
        var cars = await _carService.GetAllCarsAsync(brandId);

        return Ok(cars);
    }

    [HttpPost]
    public async Task<IActionResult> AddCar([FromBody] CreateCarRequest createCarRequest)
    {
        var id = await _carService.AddCarAsync(createCarRequest);

        return Ok(new { id = id });
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateCar([FromRoute] int id, [FromBody] UpdateCarRequest updateCarRequest)
    {
        await _carService.UpdateCarAsync(id, updateCarRequest);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCar([FromRoute] int id)
    {
        await _carService.DeleteCarAsync(id);

        return NoContent();
    }
}
