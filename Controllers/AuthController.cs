using Loan_API.DTO;
using Loan_API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    [HttpPost("login")]
    public IActionResult Login(UserLoginDto userLoginDto)
    {
        var token = _authService.Login(userLoginDto);
        if (token == null)
        {
            return Unauthorized();
        }
        return Ok(new { Token = token });
    }
}