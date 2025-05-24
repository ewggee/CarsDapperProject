using CarsDapperProject.Contracts.DTOs;
using CarsDapperProject.Contracts.DTOs.Requests.Brand;
using CarsDapperProject.Domain.Entities;

namespace CarsDapperProject.Application.Mappers;

public static class BrandMapper
{
    public static Brand MapToEntity(this BrandDto _)
    {
        return new Brand
        {
            Id = _.Id,
            Name = _.Name
        };
    }

    public static BrandDto MapToDto(this Brand _)
    {
        return new BrandDto
        {
            Id = _.Id,
            Name = _.Name
        };
    }

    public static Brand MapToEntity(this CreateBrandRequest _)
    {
        return new Brand
        {
            Name = _.Name
        };
    }

    public static Brand MapToEntity(this UpdateBrandRequest _)
    {
        return new Brand
        {
            Name = _.Name
        };
    }
}
