using System.ComponentModel.DataAnnotations;

public class UserDto
{
    [Required]
    [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Name must contain only letters and no spaces.")]
    public string Name { get; set; }

    [Required]
    [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "Surname must contain only letters and no spaces.")]
    public string Surname { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Mail { get; set; }

    [Required]
    [MinLength(4)]
    public string Username { get; set; }

    [Required]
    [MinLength(6)]
    public string Password { get; set; }

    [Range(18, 120, ErrorMessage = "User must be at least 18 years old.")]
    public int Age { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number.")]
    public decimal MonthlySalary { get; set; }
}
