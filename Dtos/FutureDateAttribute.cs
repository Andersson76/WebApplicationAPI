using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos;

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not DateTime dt)
            return ValidationResult.Success;

        // Date får inte vara i dåtid
        if (dt.Date < DateTime.UtcNow.Date)
            return new ValidationResult("Date får inte vara i dåtid.");

        return ValidationResult.Success;
    }
}
