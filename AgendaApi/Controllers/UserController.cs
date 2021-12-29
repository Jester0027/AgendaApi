using AgendaApi.Repository.User;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetAllUsers([FromQuery] int? page, [FromQuery] int? limit = 10)
        {
            return page != null
                ? Ok(_userRepository.GetPage((int) page, limit ?? 10))
                : Ok(_userRepository.FindAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}