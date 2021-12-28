using System.Collections.Generic;
using System.Linq;
using AgendaApi.Data;

namespace AgendaApi.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Model.User.User> FindAll()
        {
            return _db.Users.ToList();
        }

        public Model.User.User GetById(int id)
        {
            return _db.Users.SingleOrDefault(u => u.Id == id);
        }

        public bool Add(Model.User.User user)
        {
            _db.Users.Add(user);
            return Save();
        }

        public bool Update(Model.User.User user)
        {
            _db.Users.Update(user);
            return Save();
        }

        public bool Delete(int id)
        {
            return Delete(GetById(id));
        }

        public bool Delete(Model.User.User user)
        {
            _db.Users.Remove(user);
            return Save();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0;
        }
    }
}