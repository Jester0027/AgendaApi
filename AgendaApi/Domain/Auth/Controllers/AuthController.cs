using AgendaApi.Domain.Auth.Services;
using AgendaApi.Domain.User.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Domain.Auth.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login", Name = "Login")]
        public IActionResult Login([FromBody] UserLoginDto userLoginDto)
        {
            var token = _authService.Login(_authService.Authenticate(userLoginDto.Email, userLoginDto.Password));
            if (token == null)
            {
                return BadRequest(new {message = "Wrong Email address or password"});
            }

            return Ok(new
            {
                token
            });
        }

        [HttpPost("register", Name = "Register")]
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