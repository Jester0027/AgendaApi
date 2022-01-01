using AgendaApi.Domain.User.Models;
using AgendaApi.Domain.User.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AgendaApi.Domain.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AuthService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        private bool UserAlreadyExists(string username)
        {
            return _userRepository.GetByEmail(username) != null;
        }

        public User.Models.User Authenticate(string username, string password)
        {
            var user = _userRepository.GetByEmail(username);
            var passwordHasher = new PasswordHasher<User.Models.User>();
            var result = passwordHasher.VerifyHashedPassword(user, user.Password, password);
            return result == PasswordVerificationResult.Success ? user : null;
        }

        public User.Models.User Register(UserCreateDto userCreateDto)
        {
            if (UserAlreadyExists(userCreateDto.Email))
            {
                return null;
            }

            var user = _mapper.Map<User.Models.User>(userCreateDto);
            var passwordHasher = new PasswordHasher<User.Models.User>();
            var pass = passwordHasher.HashPassword(user, user.Password);
            user.Password = pass;
            return _userRepository.Add(user);
        }
    }
}