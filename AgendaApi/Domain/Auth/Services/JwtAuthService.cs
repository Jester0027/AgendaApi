using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AgendaApi.Domain.User.Models;
using AgendaApi.Domain.User.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AgendaApi.Domain.Auth.Services
{
    public class JwtAuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public JwtAuthService(IConfiguration configuration, IUserRepository userRepository, IMapper mapper)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public bool UserAlreadyExists(string username)
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

        public string Login(User.Models.User user)
        {
            if (user == null)
            {
                return null;
            }
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
            var credentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
            var tokenHandler = new JwtSecurityTokenHandler();
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.Name, user.Email),
                    new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials
            };
            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
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