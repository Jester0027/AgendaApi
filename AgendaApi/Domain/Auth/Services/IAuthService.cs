using AgendaApi.Domain.User.Models;

namespace AgendaApi.Domain.Auth.Services
{
    public interface IAuthService
    {
        User.Models.User Authenticate(string username, string password);
        User.Models.User Register(UserCreateDto userCreateDto);
    }
}