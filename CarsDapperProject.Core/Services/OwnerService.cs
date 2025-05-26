using CarsDapperProject.Application.Mappers;
using CarsDapperProject.Contracts.DTOs;
using CarsDapperProject.Contracts.DTOs.Requests.Owner;
using CarsDapperProject.Domain.Exceptions.Car;
using CarsDapperProject.Domain.Exceptions.Owner;
using CarsDapperProject.Domain.Repositories;

namespace CarsDapperProject.Application.Services;

public class OwnerService
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly ICarRepository _carRepository;

    public OwnerService(IOwnerRepository ownerRepository, ICarRepository carRepository)
    {
        _ownerRepository = ownerRepository;
        _carRepository = carRepository;
    }

    public async Task<OwnerWithCarDto> GetOwnerByIdAsync(int id)
    {
        var owner = await _ownerRepository.GetByIdAsync(id)
            ?? throw new OwnerNotFoundException(id);

        var cars = await _carRepository.GetAllCarsByOwnerAsync(id);

        return owner.MapToDto(cars);
    }

    public async Task<IEnumerable<OwnerDto>> GetAllOwnersAsync()
    {
        var owners = await _ownerRepository.GetAllAsync();

        return owners.Select(o => o.MapToDto());
    }

    public async Task<int> AddOwnerAsync(CreateOwnerRequest createOwnerRequest)
    {
        var id = await _ownerRepository.AddAsync(createOwnerRequest.MapToEntity());

        return id;
    }

    public async Task UpdateOwnerAsync(int id, UpdateOwnerRequest updateOwnerRequest)
    {
        var owner = updateOwnerRequest.MapToEntity();
        owner.Id = id;

        await _ownerRepository.UpdateAsync(owner);
    }

    public async Task DeleteOwnerAsync(int id)
    {
        var deletedRows = await _ownerRepository.DeleteAsync(id);

        if (deletedRows == 0)
            throw new OwnerNotFoundException(id);
    }
}
