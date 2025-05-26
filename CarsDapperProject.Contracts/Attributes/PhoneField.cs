using System.ComponentModel.DataAnnotations;

namespace CarsDapperProject.Contracts.Attributes;

public class PhoneField() : RegularExpressionAttribute(@"^\+7\s\(\d{3}\)\s\d{3}\s\d{2}-\d{2}$")
{
    public override string FormatErrorMessage(string name)
    {
        if (string.IsNullOrEmpty(ErrorMessage))
        {
            ErrorMessage = $"Поле {name} должно иметь вид: +7 (XXX) XXX XX-XX";
        }

        return base.FormatErrorMessage(name);
    }
}
