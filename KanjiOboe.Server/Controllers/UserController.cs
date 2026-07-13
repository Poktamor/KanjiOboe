using KanjiOboe.Server.DTOs;
using KanjiOboe.Server.Service;
using Microsoft.AspNetCore.Mvc;

namespace KanjiOboe.Server.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUserAsync([FromBody] RegisterUserDTO registerUserDTO)
        {
            await _userService.RegisterUserAsync(registerUserDTO);
            return Ok(new { message = "User registered successfully" });
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginUserAsync([FromBody] LoginUserDTO loginUserDTO)
        {
            bool isValid = await _userService.ValidatePassword(loginUserDTO.Email, loginUserDTO.Password);
            if (!isValid)
            {
                return Unauthorized(new { message = "Invalid email or password" });
            }
            return Ok(new { message = "Login successful" });
        }

    }
}
