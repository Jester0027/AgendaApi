using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AgendaApi.Domain.Auth.Services
{
    public class JwtUserService : IJwtService<User.Models.User>
    {
        private readonly SymmetricSecurityKey _secret;
        private readonly SigningCredentials _credentials;

        public JwtUserService(IConfiguration configuration)
        {
            _secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]));
            _credentials = new SigningCredentials(_secret, SecurityAlgorithms.HmacSha256);
        }

        private SecurityTokenDescriptor GetTokenDescriptor(User.Models.User user)
        {
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.Name, user.Email),
                    new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = _credentials
            };
            return descriptor;
        }

        public string Sign(User.Models.User item)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var descriptor = GetTokenDescriptor(item);
            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool Validate(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    IssuerSigningKey = _secret,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out var validatedToken);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}