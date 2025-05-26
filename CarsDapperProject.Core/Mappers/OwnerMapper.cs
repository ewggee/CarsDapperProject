using CarsDapperProject.Contracts.DTOs;
using CarsDapperProject.Contracts.DTOs.Requests.Owner;
using CarsDapperProject.Domain.Entities;
using CarsDapperProject.Domain.QueryModels.Car;

namespace CarsDapperProject.Application.Mappers;

public static class OwnerMapper
{
    public static OwnerWithCarDto MapToDto(this Owner _, IEnumerable<CarWithBrand> cars)
    {
        return new OwnerWithCarDto
        {
            Id = _.Id,
            Name = _.Name,
            Phone = _.Phone,
            Email = _.Email,
            Cars = cars.Select(c => new CarWithBrandDto
            {
                Brand = c.Brand,
                Model = c.Model
            }).ToList()
        };
    }

    public static OwnerDto MapToDto(this Owner _)
    {
        return new OwnerDto
        {
            Id = _.Id,
            Name = _.Name,
            Phone = _.Phone,
            Email = _.Email
        };
    }

    public static Owner MapToEntity(this CreateOwnerRequest _)
    {
        return new Owner
        {
            Name = _.Name,
            Phone = _.Phone,
            Email = _.Email
        };
    }

    public static Owner MapToEntity(this UpdateOwnerRequest _)
    {
        return new Owner
        {
            Name = _.Name,
            Phone = _.Phone,
            Email = _.Email
        };
    }
}
