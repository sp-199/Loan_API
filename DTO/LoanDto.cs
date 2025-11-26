using Loan_API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loan_API.DTO
{
    public class LoanDto
    {

        public LoanType LoanType { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; } // e.g., USD, GEL, EUR

        public int PeriodMonths { get; set; } // loan duration in months

    }
}
