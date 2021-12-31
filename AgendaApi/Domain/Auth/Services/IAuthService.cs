using AgendaApi.Domain.User.Models;

namespace AgendaApi.Domain.Auth.Services
{
    public interface IAuthService
    {
        bool UserAlreadyExists(string username);
        User.Models.User Authenticate(string username, string password);
        string Login(User.Models.User user);
        User.Models.User Register(UserCreateDto userCreateDto);
    }
}