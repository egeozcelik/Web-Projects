using EgeBlogSite.CORE.SingletonObject;
using EgeBlogSite.CORE.UnitOfWork;
using EgeBlogSite.DAL;
using EgeBlogSite.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgeBlogSite.BLL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        BlogSiteEntities db;
        UnitOfWork UoW;
        public UserRepository()
        {
            db = SingletonDB.GetInstance();
            UoW = new UnitOfWork();
        }
        public User Add(User entity)
        {
            db.Users.Add(entity);
            UoW.Save();
            return entity;
            
        }

        public User Delete(User entity)
        {  
            db.Users.Remove(entity);
            UoW.Save();
            return entity;
        }

        public List<User> GetAll()
        {
            return db.Users.ToList();
        }

        public User GetById(int Id)
        {
            return db.Users.FirstOrDefault(z => z.Id == Id);

        }

        public void Update(User entity)
        {
            User u = db.Users.FirstOrDefault(z => z.Id == entity.Id);
            u.Name = entity.Name;
            u.Surname = entity.Surname;
            u.Password = entity.Password;
            u.Role = entity.Role;
            u.Email = entity.Email;
            UoW.Save();
          

        }
    }
}
