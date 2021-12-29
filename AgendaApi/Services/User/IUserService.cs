using System.Collections.Generic;
using AgendaApi.Model.Page;
using AgendaApi.Model.User;

namespace AgendaApi.Services.User
{
    public interface IUserService
    {
        Page<UserDto> GetPage(int page, int limit);
        List<UserDto> GetAll();
        UserDto GetById(int id);
        Model.User.User Create(UserCreateDto userCreateDto);
        bool Update(UserUpdateDto userUpdateDto);
        bool Delete(Model.User.User user);
        bool Delete(int id);
    }
}