using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Loan_API.Models
{
    // Enum for type of loan
    public enum LoanType
    {
        CarLoan,
        Mortgage,
        QuickLoan,
        PersonalLoan
    }

    // Enum for loan status
    public enum LoanStatus
    {
        Processing,
        Accepted,
        Rejected
    }

    public class Loan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public LoanType LoanType { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(3)]
        public string Currency { get; set; } // e.g., USD, GEL, EUR

        [Required]
        public int PeriodMonths { get; set; } // loan duration in months

        [Required]
        public LoanStatus Status { get; set; } = LoanStatus.Processing;

        // Foreign key to User
        [Required]
        public int UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }
}
