using KanjiOboe.Server.Database.Entities;
using KanjiOboe.Server.DTOs;
using KanjiOboe.Server.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [Authorize]
        [HttpGet("profile")]  
        public ActionResult GetProfile()
        {
            return Ok(User.FindFirstValue(ClaimTypes.Name));
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
            User? user = await _userService.AuthenticateAsync(loginUserDTO.Email, loginUserDTO.Password);
            if (user == null)
            {
                return Unauthorized(new { message = "Invalid email or password" });
            }

            if (user == null)
            {
                return Unauthorized(new { message = "Invalid email or password" });
            }

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
                });


            return Ok(new { message = "Login successful" });
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> UserDeleteAsync(long id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
        [Authorize]
        [HttpDelete]
        public async Task<ActionResult>  UserDeleteSelfAsync()
        {
            var currentUserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            await _userService.DeleteUserAsync(currentUserId);
            return NoContent();
        }

    }
}
