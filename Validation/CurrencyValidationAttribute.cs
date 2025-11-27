using System.ComponentModel.DataAnnotations;

namespace Loan_API.Validation
{
    public class CurrencyValidationAttribute : ValidationAttribute
    {
        private static readonly string[] Allowed = { "GEL", "USD", "EUR" };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("Currency is required.");

            string currency = value.ToString().ToUpper();

            if (!Allowed.Contains(currency))
                return new ValidationResult($"Currency must be one of: {string.Join(", ", Allowed)}");

            return ValidationResult.Success;
        }
    }
}
