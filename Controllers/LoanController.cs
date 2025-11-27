using Loan_API.DTO;
using Loan_API.Models;
using Loan_API.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace Loan_API.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILogger<LoanController> _logger;
        private readonly ILoanService _loanService;
        public LoanController(ILoanService loanService, ILogger<LoanController>logger)
        {
            _logger = logger;
            _loanService = loanService;
        }


        [HttpGet("GetLoans")]
        [Authorize]
        public IActionResult GetLoans()
        {

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var loans = _loanService.DisplayLoans(userId);
            return Ok(loans);
        }


        [HttpGet("GetLoansById")]
        [Authorize(Roles ="Accountant")]
        public IActionResult GetLoans(int userId)
        {

            var loans = _loanService.DisplayLoans(userId);
            return Ok(loans);
        }



        [HttpPost("apply")]
        [Authorize]
        public IActionResult ApplyForLoan([FromBody] LoanDto loanDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (loanDto == null)
            {
                return BadRequest("Invalid loan application data.");
            }
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

                var loan = _loanService.ApplyForLoan(loanDto, userId);

                _logger.LogInformation(
                    "User {UserId} applied for a {LoanType} loan of {Amount} {Currency} for {PeriodMonths} months.",
                    userId,
                    loan.LoanType,
                    loan.Amount,
                    loan.Currency,
                    loan.PeriodMonths
                );

                return Ok(loan);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to apply loan for user {User}", User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update/{id}")]
        [Authorize (Roles = "Accountant")]
        public IActionResult UpdateLoan([FromBody] LoanDto loanDto, int id)
        {
           
            if (loanDto == null)
            {
                return BadRequest("Invalid loan update data.");
            }

            var loan = _loanService.UpdateLoan(loanDto, id);

            return Ok(loan);
        }

        [HttpDelete("delete/{id}")]
        [Authorize(Roles = "Accountant")]
        public IActionResult DeleteLoan([FromBody] LoanDto loanDto, int id)
        {
            _logger.LogInformation("User {User} deleted a loan with id = {Currency}", User.FindFirst(ClaimTypes.NameIdentifier)?.Value, loanDto.Amount, loanDto.Currency);
            if (loanDto == null)
            {
                return BadRequest("Invalid loan delete data.");
            }
            _loanService.DeleteLoan(loanDto, id);
            return NoContent();
        }
    }
}