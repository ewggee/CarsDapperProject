using System.ComponentModel.DataAnnotations;

namespace CarsDapperProject.Contracts.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
class RequiredField : RequiredAttribute
{
    public override string FormatErrorMessage(string name)
    {
        if (string.IsNullOrEmpty(ErrorMessage))
        {
            ErrorMessage = $"Поле {name} обязательно.";
        }

        return base.FormatErrorMessage(ErrorMessage);
    }
}
