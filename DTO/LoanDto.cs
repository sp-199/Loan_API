using Loan_API.Models;
using Loan_API.Validation;
using System.ComponentModel.DataAnnotations;

namespace Loan_API.DTO
{
    public class LoanDto
    {
        [Required]
        [LoanTypeValidation]
        public LoanType LoanType { get; set; }

        [Required]
        [Range(1, 1000000, ErrorMessage = "Amount must be between 1 and 1,000,000.")]
        public decimal Amount { get; set; }

        [Required]
        [CurrencyValidation]
        public string Currency { get; set; }

        [Required]
        [Range(1, 360, ErrorMessage = "Period must be between 1 and 360 months.")]
        public int PeriodMonths { get; set; }
    }
}