using System;
using System.ComponentModel.DataAnnotations;
namespace DojoSurvey.Controllers;
public class FutureDateAttribute : ValidationAttribute
{
#pragma warning disable CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
#pragma warning restore CS8765 // Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).
    {
        if (value is DateTime dateTime)
        {
            if (dateTime > DateTime.Now)
            {
                return new ValidationResult("Please enter a previous date.");
            }
        }

#pragma warning disable CS8603 // Possible null reference return.
        return ValidationResult.Success;
#pragma warning restore CS8603 // Possible null reference return.
    }
}
