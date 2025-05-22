using System.ComponentModel.DataAnnotations;

namespace CarsDapperProject.Contracts.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class StringLengthFieldAttribute(int min, int max) : LengthAttribute(min, max)
{
    public override string FormatErrorMessage(string name)
    {
        if (string.IsNullOrEmpty(ErrorMessage))
        {
            ErrorMessage = $"Поле {name} должно быть от {MinimumLength} до {MaximumLength} символов";
        }

        return base.FormatErrorMessage(name);
    }
}
