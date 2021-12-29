using System.Collections.Generic;
using AgendaApi.Model.Page;

namespace AgendaApi.Repositories.User
{
    public interface IUserRepository
    {
        List<Model.User.User> GetPage(int page, int limit);
        List<Model.User.User> FindAll();
        Model.User.User GetById(int id);
        Model.User.User Add(Model.User.User user);
        bool Update(Model.User.User user);
        bool Delete(int id);
        bool Delete(Model.User.User user);
        bool Save();
        int Count();
    }
}