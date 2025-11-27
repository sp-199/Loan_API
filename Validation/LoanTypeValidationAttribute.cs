using System.ComponentModel.DataAnnotations;

public class LoanTypeValidationAttribute : ValidationAttribute
{
    private static readonly string[] Allowed = { "Quick_Loan", "Auto_Loan", "Installment" };

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
            return new ValidationResult("Loan type is required.");

        string loanType = value.ToString();

        if (!Allowed.Contains(loanType))
            return new ValidationResult($"Loan type must be one of: {string.Join(", ", Allowed)}");

        return ValidationResult.Success;
    }
}
