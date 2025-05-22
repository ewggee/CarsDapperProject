using System.ComponentModel.DataAnnotations;

namespace CarsDapperProject.Contracts.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class RangeField(double min, double max) : RangeAttribute(min, max)
{
    public override string FormatErrorMessage(string name)
    {
        if (string.IsNullOrEmpty(ErrorMessage))
        {
            ErrorMessage = $"Поле {name} должно иметь значение в промежутке от {Minimum} до {Maximum}";
        }

        return base.FormatErrorMessage(name);
    }
}
