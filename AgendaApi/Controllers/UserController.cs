using AgendaApi.Model.User;
using AgendaApi.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers([FromQuery] int? page, [FromQuery] int? limit = 10)
        {
            if (page == null)
            {
                var users = _userService.GetAll();
                return Ok(users);
            }

            var usersPage = _userService.GetPage((int) page, limit ?? 10);
            return Ok(usersPage);
        }

        [HttpGet("{id:int}", Name = "GetUser")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserCreateDto userCreateDto)
        {
            var user = _userService.Create(userCreateDto);
            return CreatedAtRoute("GetUser", new {id = user.Id}, user);
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserUpdateDto userUpdateDto)
        {
            if (!_userService.Update(userUpdateDto))
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            if (_userService.GetById(id) == null)
            {
                return NotFound();
            }

            if (!_userService.Delete(id))
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }
    }
}