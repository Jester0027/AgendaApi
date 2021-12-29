using System;
using System.Collections.Generic;
using System.Linq;
using AgendaApi.Data;
using AgendaApi.Model.Page;

namespace AgendaApi.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Page<Model.User.User> GetPage(int page, int limit)
        {
            var count = _db.Users.Count();
            var users = _db.Users.Skip(page * limit - limit).Take(limit).ToList();
            var meta = new PageMetadata(page, limit, count);
            return new Page<Model.User.User>
            {
                Data = users,
                Meta = meta
            };
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
    }
}