
using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Validation
{
    // Custom rule: birth dates cannot be in the future.
    public class NotFutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(
            object? value,
            ValidationContext validationContext)
        {
            // A date later than today fails the rule.
            if (value is DateTime date && date.Date > DateTime.Today)
            {
                return new ValidationResult(
                    ErrorMessage ?? "The date can't be in the future.");
            }

            // Anything else passes, including an empty date.
            return ValidationResult.Success;
        }
    }
}
