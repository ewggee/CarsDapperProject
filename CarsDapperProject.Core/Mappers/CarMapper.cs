using CarsDapperProject.Contracts.DTOs;
using CarsDapperProject.Contracts.DTOs.Requests.Car;
using CarsDapperProject.Domain.Entities;
using CarsDapperProject.Domain.QueryModels.Car;

namespace CarsDapperProject.Application.Mappers;

public static class CarMapper
{
    public static Car MapToEntity(this CreateCarRequest _)
    {
        return new Car
        {
            Model = _.Model,
            BrandId = _.BrandId,
            OwnerId = _.OwnerId
        };
    }

    public static Car MapToEntity(this UpdateCarRequest _)
    {
        return new Car
        {
            Model = _.Model,
            BrandId = _.BrandId,
            OwnerId = _.OwnerId
        };
    }

    public static CarDto MapToDto(this CarWithOwner _)
    {
        return new CarDto
        {
            Id = _.Id,
            Model = _.Model,
            Owner = new ShortOwnerDto
            {
                Name = _.OwnerName
            }
        };
    }
}
