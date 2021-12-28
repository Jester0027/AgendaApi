using System.Collections.Generic;

namespace AgendaApi.Repository.User
{
    public interface IUserRepository
    {
        List<Model.User.User> FindAll();
        Model.User.User GetById(int id);
        bool Add(Model.User.User user);
        bool Update(Model.User.User user);
        bool Delete(int id);
        bool Delete(Model.User.User user);
        bool Save();
    }
}