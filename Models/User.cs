namespace Loan_API.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Username { get; set; }
    public string Mail { get; set; }
    public int Age { get; set; }
    public decimal MonthlySalary { get; set; }
    public bool IsBlocked { get; set; } = false;
    public string PasswordHash { get; set; }

    public string Role { get; set; } = "User"; // or "Accountant"

    public ICollection<Loan> Loans { get; set; }
}