using CarsDapperProject.Contracts.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CarsDapperProject.Contracts.DTOs.Requests.Owner;

public class UpdateOwnerRequest
{
    [StringLengthField(1, 100)]
    public string Name { get; set; }

    [PhoneField]
    public string Phone { get; set; }

    [StringLengthField(1, 100)]
    [EmailAddress]
    public string Email { get; set; }
}
