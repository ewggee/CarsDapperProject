using System.ComponentModel.DataAnnotations;

namespace CarsDapperProject.Contracts.DTOs;

public class CreateBrandRequest
{
    [Required(ErrorMessage = $"Поле {nameof(Name)} обязательно.")]
    [Length(1, 100, ErrorMessage = $"Поле {nameof(Name)} должно быть от 1 до 100 символов.")]
    public string Name { get; set; }
}
