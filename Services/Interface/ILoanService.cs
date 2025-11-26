using Loan_API.DTO;
using Loan_API.Models;

namespace Loan_API.Services.Interface
{
    public interface ILoanService
    {
        Loan ApplyForLoan(LoanDto loanDto, int id);
        List<Loan> DisplayLoans(int userId);

        Loan UpdateLoan(LoanDto loanDto, int id);

        void DeleteLoan(LoanDto loanDto, int id);
    }
}
