using CarsDapperProject.Application.Abstractions;
using CarsDapperProject.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CarsDapperProject.WebAPI.Controllers;

[Route("api/brands")]
[ApiController]
public class BrandController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBrandById([FromRoute] int id)
    {
        var brand = await _brandService.GetBrandByIdAsync(id);

        return Ok(brand);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBrands()
    {
        var brands = await _brandService.GetAllBrandsAsync();

        return Ok(brands);
    }

    [HttpPost]
    public async Task<IActionResult> AddBrand([FromBody] BrandRequest createBrandRequest)
    {
        var brandId = await _brandService.AddBrandAsync(createBrandRequest); 

        return Ok(new { id = brandId });
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateBrand([FromRoute] int id, [FromBody] BrandRequest updateBrandRequest)
    {
        await _brandService.UpdateBrandAsync(id, updateBrandRequest);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBrand([FromRoute] int id)
    {
        await _brandService.DeleteBrandAsync(id);

        return NoContent();
    }
}
