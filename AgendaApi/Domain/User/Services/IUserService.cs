using System.Collections.Generic;
using AgendaApi.Domain.User.Models;
using AgendaApi.Models.Page;

namespace AgendaApi.Domain.User.Services
{
    public interface IUserService
    {
        Page<UserDto> GetPage(int page, int limit);
        List<UserDto> GetAll();
        UserDto GetById(int id);
        Models.User Create(UserCreateDto userCreateDto);
        bool Update(UserUpdateDto userUpdateDto);
        bool Delete(Models.User user);
        bool Delete(int id);
    }
}