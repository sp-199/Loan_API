using Loan_API.Data;
using Loan_API.DTO;
using Loan_API.Models;
using Loan_API.Services.Interface;
using Microsoft.EntityFrameworkCore;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _dbContext;
    public UserService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public User Registration(UserDto userDto)
    {
        var user = new User
        {
            Name = userDto.Name,
            Surname = userDto.Surname,
            Username = userDto.Username,
            Mail = userDto.Mail,
            Age = userDto.Age,
            MonthlySalary = userDto.MonthlySalary,
            PasswordHash = AuthService.HashPassword(userDto.Password),
            Role = "User"
        };
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
        return user;
    }
    public User GetUserById(int id)
    {

        var user = _dbContext.Users
            .Include(u => u.Loans)
            .FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        else
        {
            return user;
        }
    }
    public void BlockUser(int id)
    {
        var user = _dbContext.Users.Find(id);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        user.IsBlocked = true;
        _dbContext.SaveChanges();
    }
}