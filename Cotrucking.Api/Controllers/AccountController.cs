using Cotrucking.Domain.Models;
using Cotrucking.Infrastructure.Migrations;
using Cotrucking.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cotrucking.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserService _userService;

        public AccountController(ILogger<AccountController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel login)
        {
            var user = await _userService.Login(login);
            if (user == null) 
            {
                return Unauthorized();
            }
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserInput user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please provide all required fields");
            }
            await _userService.Register(user);
            return Ok();
        }


        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequest refreshTokenRequest)
        {
            var refreshToken = await _userService.RefreshToken(refreshTokenRequest);
            if (refreshToken == null)
            {
                return Unauthorized();
            }
            return Ok(refreshToken);
        }
    }
}
