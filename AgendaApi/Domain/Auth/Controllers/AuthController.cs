using AgendaApi.Domain.Auth.Services;
using AgendaApi.Domain.User.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Domain.Auth.Controllers
{
    [ApiController]
    // [Authorize]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtService<User.Models.User> _jwtUserService;

        public AuthController(IAuthService authService, IJwtService<User.Models.User> jwtUserService)
        {
            _authService = authService;
            _jwtUserService = jwtUserService;
        }

        [HttpGet("validate")]
        [AllowAnonymous]
        public IActionResult Validate([FromQuery] string token)
        {
            var isValid = _jwtUserService.Validate(token);
            return isValid ? NoContent() : Unauthorized();
        }

        [HttpPost("login", Name = "Login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UserLoginDto userLoginDto)
        {
            var user = _authService.Authenticate(userLoginDto.Email, userLoginDto.Password);
            if (user == null)
            {
                return BadRequest(new {message = "Wrong Email address or password"});
            }
            return Ok(new {token = _jwtUserService.Sign(user)});
        }

        [HttpPost("register", Name = "Register")]
        [Authorize(Roles = "Secretary")]
        [ValidateAntiForgeryToken]
        public IActionResult Register([FromBody] UserCreateDto userCreateDto)
        {
            var user = _authService.Register(userCreateDto);
            if (user == null)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}