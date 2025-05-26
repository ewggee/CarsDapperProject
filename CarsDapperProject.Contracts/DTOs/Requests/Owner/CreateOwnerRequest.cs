using CarsDapperProject.Contracts.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CarsDapperProject.Contracts.DTOs.Requests.Owner;

public class CreateOwnerRequest
{
    [RequiredField]
    [StringLengthField(1, 100)]
    public string Name { get; set; }

    [RequiredField]
    [PhoneField]
    public string Phone { get; set; }

    [RequiredField]
    [StringLengthField(1, 100)]
    [EmailAddress]
    public string Email { get; set; }
}
