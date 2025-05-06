using IdentityService.DTOs;
using IdentityService.Services;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var loggedInUser = await _userService.LoginUser(login);
            return Ok(loggedInUser);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto user)
        {
            var loggedInUser = await _userService.RegisterUser(user);
            return Ok(loggedInUser);
        }
    }
}
