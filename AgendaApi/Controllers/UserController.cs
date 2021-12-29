using System;
using System.Linq;
using AgendaApi.Model.Page;
using AgendaApi.Model.User;
using AgendaApi.Repository.User;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AgendaApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllUsers([FromQuery] int? page, [FromQuery] int? limit = 10)
        {
            if (page == null)
            {
                var users = _userRepository.FindAll();
                var dtos = users.Select(u => _mapper.Map<UserDto>(u)).ToList();
                return Ok(dtos);
            }

            var usersPage = _userRepository.GetPage((int) page, limit ?? 10);
            var userDtos = usersPage.Data.Select(u => _mapper.Map<UserDto>(u)).ToList();
            return Ok(new Page<UserDto>
            {
                Data = userDtos,
                Meta = usersPage.Meta
            });
        }

        [HttpGet("{id:int}", Name = "GetUser")]
        public IActionResult GetUserById(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserCreateDto userCreateDto)
        {
            var user = _mapper.Map<User>(userCreateDto);
            _userRepository.Add(user);
            return CreatedAtRoute("GetUser", new {id = user.Id}, user);
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserUpdateDto userUpdateDto)
        {
            var user = _mapper.Map<User>(userUpdateDto);
            if (!_userRepository.Update(user))
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            if (_userRepository.GetById(id) == null)
            {
                return NotFound();
            }

            if (!_userRepository.Delete(id))
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }
    }
}