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
    public class CategoryRepository : IRepository<Category>
    {
        BlogSiteEntities db;
        UnitOfWork UoW;
        public CategoryRepository()
        {
            db = SingletonDB.GetInstance();
            UoW = new UnitOfWork();
        }
        public Category Add(Category entity)
        {
            db.Categories.Add(entity);
            UoW.Save();
            return entity;

        }

        public Category Delete(Category entity)
        {
            db.Categories.Remove(entity);
            UoW.Save();
            return entity;
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public Category GetById(int Id)
        {
            return db.Categories.FirstOrDefault(z => z.Id == Id);

        }

        public void Update(Category entity)
        {
            Category c = db.Categories.FirstOrDefault(z => z.Id == entity.Id);
            c.Name = entity.Name;
            c.Articles = entity.Articles;
            
            UoW.Save();
        }
    }
}
