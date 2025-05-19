using CarsDapperProject.Application.DTOs;
using CarsDapperProject.Domain.Entities;

namespace CarsDapperProject.Application.Extensions;

public static class BrandExtension
{
    public static Brand MapToEntity(this BrandDto brandDto)
    {
        return new Brand 
        {
            Id = brandDto.Id,
            Name = brandDto.Name 
        };
    }

    public static BrandDto MapToDto(this Brand brand)
    {
        return new BrandDto
        {
            Id = brand.Id,
            Name = brand.Name
        };
    }

    public static Brand MapToEntity(this BrandRequest createBrandRequest)
    {
        return new Brand
        {
            Name = createBrandRequest.Name
        };
    }
}
