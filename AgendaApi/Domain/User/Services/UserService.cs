using System.Collections.Generic;
using System.Linq;
using AgendaApi.Domain.User.Models;
using AgendaApi.Domain.User.Repositories;
using AgendaApi.Models.Page;
using AutoMapper;

namespace AgendaApi.Domain.User.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Page<UserDto> GetPage(int page, int limit)
        {
            var count = _userRepository.Count();
            var users = _userRepository.GetPage(page, limit).Select(u => _mapper.Map<UserDto>(u)).ToList();
            var meta = new PageMetadata(page, limit, count);
            return new Page<UserDto>
            {
                Data = users,
                Meta = meta
            };
        }

        public List<UserDto> GetAll()
        {
            return _userRepository.FindAll().Select(u => _mapper.Map<UserDto>(u)).ToList();
        }

        public UserDto GetById(int id)
        {
            return _mapper.Map<UserDto>(_userRepository.GetById(id));
        }

        public Models.User Create(UserCreateDto userCreateDto)
        {
            return _userRepository.Add(_mapper.Map<Models.User>(userCreateDto));
        }

        public bool Update(UserUpdateDto userUpdateDto)
        {
            return _userRepository.Update(_mapper.Map<Models.User>(userUpdateDto));
        }

        public bool Delete(Models.User user)
        {
            return _userRepository.Delete(user);
        }

        public bool Delete(int id)
        {
            return _userRepository.Delete(id);
        }
    }
}