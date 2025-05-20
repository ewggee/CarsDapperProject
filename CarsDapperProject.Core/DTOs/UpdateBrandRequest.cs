using System.ComponentModel.DataAnnotations;

namespace CarsDapperProject.Application.DTOs;

public class UpdateBrandRequest
{
    [Length(1, 100, ErrorMessage = $"Поле {nameof(Name)} должно быть от 1 до 100 символов.")]
    public string Name { get; set; }
}
