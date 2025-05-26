using CarsDapperProject.Application.Services;
using CarsDapperProject.Contracts.DTOs.Requests.Owner;
using CarsDapperProject.WebAPI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CarsDapperProject.WebAPI.Controllers;

[Route("api/owners")]
[ApiController]
[TypeFilter<ApiExceptionFilter>]
public class OwnerController : ControllerBase
{
    private readonly OwnerService _ownerService;

    public OwnerController(OwnerService carService)
    {
        _ownerService = carService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOwnerById([FromRoute] int id)
    {
        var owner = await _ownerService.GetOwnerByIdAsync(id);

        return Ok(owner);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOwners()
    {
        var owners = await _ownerService.GetAllOwnersAsync();

        return Ok(owners);
    }

    [HttpPost]
    public async Task<IActionResult> AddOwner([FromBody] CreateOwnerRequest createOwnerRequest)
    {
        var id = await _ownerService.AddOwnerAsync(createOwnerRequest);

        return Ok(new { id = id });
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateOwner([FromRoute] int id, [FromBody] UpdateOwnerRequest updateOwnerRequest)
    {
        await _ownerService.UpdateOwnerAsync(id, updateOwnerRequest);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOwner([FromRoute] int id)
    {
        await _ownerService.DeleteOwnerAsync(id);

        return NoContent();
    }
}
