using Loan_API.DTO;
using Loan_API.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }


    [HttpPost("register")]
    public IActionResult RegisterUser([FromBody] UserDto userDto)
    {
        var user = _userService.Registration(userDto);
        return Ok(user);
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetUserById(int id)
    {
        var user = _userService.GetUserById(id);
        return Ok(user);
    }

    [HttpPut("block/{id}")]
    [Authorize(Roles = "Accountant")]
    public IActionResult BlockUser(int id)
    {
        _userService.BlockUser(id);
        return NoContent();
    }
}