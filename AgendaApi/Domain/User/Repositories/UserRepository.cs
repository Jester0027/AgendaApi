using System.Collections.Generic;
using System.Linq;
using AgendaApi.Data;

namespace AgendaApi.Domain.User.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Models.User> GetPage(int page, int limit)
        {
            return _db.Users.Skip(page * limit - limit).Take(limit).ToList();
        }

        public List<Models.User> FindAll()
        {
            return _db.Users.ToList();
        }

        public Models.User GetById(int id)
        {
            return _db.Users.SingleOrDefault(u => u.Id == id);
        }

        public Models.User GetByEmail(string email)
        {
            return _db.Users.FirstOrDefault(u => u.Email.ToLower().Trim() == email.ToLower().Trim());
        }

        public Models.User Add(Models.User user)
        {
            var userEntity = _db.Users.Add(user);
            Save();
            return userEntity.Entity;
        }

        public bool Update(Models.User user)
        {
            _db.Users.Update(user);
            return Save();
        }

        public bool Delete(int id)
        {
            return Delete(GetById(id));
        }

        public bool Delete(Models.User user)
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