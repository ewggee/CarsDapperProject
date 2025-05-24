using CarsDapperProject.Contracts.Attributes;

namespace CarsDapperProject.Contracts.DTOs.Requests.Brand;

public class CreateBrandRequest
{
    [RequiredField]
    [StringLengthField(min: 1, max: 100)]
    public string Name { get; set; }
}
