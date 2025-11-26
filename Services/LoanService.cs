using Loan_API.DTO;
using Loan_API.Services.Interface;
using Loan_API.Models;
using Loan_API.Data;
using Microsoft.OpenApi.Models;

namespace Loan_API.Services;
public class LoanService : ILoanService
{
    private readonly ApplicationDbContext _dbContext;
    public LoanService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Loan ApplyForLoan(LoanDto loanDto, int userId)
    {
        var user = _dbContext.Users.Find(userId);
        if (user.IsBlocked)
        {
            throw new Exception("User is black-listed");
        }
        // Map LoanDto to Loan entity
        var loan = new Loan
        {
            UserId = userId,
            LoanType = loanDto.LoanType,
            Amount = loanDto.Amount,
            Currency = loanDto.Currency,
            PeriodMonths = loanDto.PeriodMonths,
            Status = LoanStatus.Processing // Default status
        };
        // Here you would typically save the loan to the database
        _dbContext.Loans.Add(loan);
        _dbContext.SaveChanges();
        return loan;
    }
    public List<Loan> DisplayLoans(int userId)
    {
        var loans = _dbContext.Loans.Where(u => u.UserId == userId).ToList();

        return loans;
    }

    public Loan UpdateLoan(LoanDto loanDto, int id)
    {
        var loan = _dbContext.Loans.Find(id);
        if (loan == null)
        {
            throw new Exception("Loan not found");
        }
        // Update loan properties
        loan.LoanType = loanDto.LoanType;
        loan.Amount = loanDto.Amount;
        loan.Currency = loanDto.Currency;
        loan.PeriodMonths = loanDto.PeriodMonths;
        _dbContext.SaveChanges();
        return loan;
    }

    public void DeleteLoan(LoanDto loanDto, int id)
    {
        var loan = _dbContext.Loans.Find(id);
        if (loan == null)
        {
            throw new Exception("Loan not found");
        }
        _dbContext.Loans.Remove(loan);
        _dbContext.SaveChanges();
    }
}