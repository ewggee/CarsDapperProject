using CarsDapperProject.Contracts.Attributes;

namespace CarsDapperProject.Contracts.DTOs.Requests.Car;

public class CreateCarRequest
{
    [RequiredField]
    [StringLengthField(min: 1, max: 100)]
    public string Model { get; set; }

    [RequiredField]
    [RangeField(min: 1, max: int.MaxValue)]
    public int BrandId { get; set; }

    [RangeField(min: 1, max: int.MaxValue)]
    public int? OwnerId { get; set; }
}
