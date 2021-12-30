using System.Collections.Generic;

namespace AgendaApi.Domain.User.Repositories
{
    public interface IUserRepository
    {
        List<Models.User> GetPage(int page, int limit);
        List<Models.User> FindAll();
        Models.User GetById(int id);
        Models.User Add(Models.User user);
        bool Update(Models.User user);
        bool Delete(int id);
        bool Delete(Models.User user);
        bool Save();
        int Count();
    }
}