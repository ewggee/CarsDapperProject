using System.ComponentModel.DataAnnotations;

namespace CarsDapperProject.Contracts.DTOs;

public class UpdateBrandRequest
{
    [Length(1, 100, ErrorMessage = $"Поле {nameof(Name)} должно быть от 1 до 100 символов.")]
    public string Name { get; set; }
}
