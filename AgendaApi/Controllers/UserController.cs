using AgendaApi.Model.User;
using AgendaApi.Services.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AgendaApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetUsers([FromQuery] int? page, [FromQuery] int? limit = 10)
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
            _logger.LogDebug("User inserted : {user}", JsonConvert.SerializeObject(user));
            return CreatedAtRoute("GetUser", new {id = user.Id}, user);
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserUpdateDto userUpdateDto)
        {
            if (!_userService.Update(userUpdateDto))
            {
                _logger.LogDebug("An error occured while updating the user : {user}", JsonConvert.SerializeObject(userUpdateDto));
                return BadRequest(ModelState);
            }
            
            _logger.LogDebug("User updated : {user}", JsonConvert.SerializeObject(userUpdateDto));
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            if (_userService.GetById(id) == null)
            {
                _logger.LogDebug("User not found at id : {id}", id);
                return NotFound();
            }

            if (!_userService.Delete(id))
            {
                _logger.LogDebug("An error occured while deleting the user with the id : {id}", id);
                return BadRequest(ModelState);
            }

            _logger.LogDebug("User with id \"{id}\" successfully deleted", id);
            return NoContent();
        }
    }
}