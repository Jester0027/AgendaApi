using System.Collections.Generic;
using System.Linq;
using AgendaApi.Data;
using AgendaApi.Model.Page;

namespace AgendaApi.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Model.User.User> GetPage(int page, int limit)
        {
            return _db.Users.Skip(page * limit - limit).Take(limit).ToList();
        }

        public List<Model.User.User> FindAll()
        {
            return _db.Users.ToList();
        }

        public Model.User.User GetById(int id)
        {
            return _db.Users.SingleOrDefault(u => u.Id == id);
        }

        public Model.User.User Add(Model.User.User user)
        {
            var userEntity = _db.Users.Add(user);
            Save();
            return userEntity.Entity;
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

        public int Count()
        {
            return _db.Users.Count();
        }
    }
}