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
    public class ArticleRepository : IRepository<Article>
    {
        BlogSiteEntities db;
        UnitOfWork UoW;
        public ArticleRepository()
        {
            db = SingletonDB.GetInstance();
            UoW = new UnitOfWork();
        }
        public Article Add(Article entity)
        {
            db.Articles.Add(entity);
            UoW.Save();
            return entity;
        }

        public Article Delete(Article entity)
        {
            db.Articles.Remove(entity);
            UoW.Save();
            return entity;

        }

        public List<Article> GetAll()
        {
           return db.Articles.ToList();
        }

        public Article GetById(int Id)
        {
            return db.Articles.FirstOrDefault(z=>z.Id == Id);
        }

        public void Update(Article entity)
        {
            Article A = db.Articles.FirstOrDefault(z => z.Id == entity.Id);
            A.Text = entity.Text;
            A.Title = entity.Title;
            
            A.CategoryId = entity.CategoryId;
            UoW.Save();
        }
    }
}
