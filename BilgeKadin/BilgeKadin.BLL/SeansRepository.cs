using BilgeKadin.DAL;
using BilgeKadin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BilgeKadin.BLL
{
    public class SeansRepository : IRepository<Seans>
    {
        BilgeKadinEntities db = SingletonInstancePerLifeTime.GetContextInstance();
        public Seans Add(Seans entity)
        {
            db.Seanslar.Add(entity);
            db.SaveChanges();
            return entity;

        }

        public void Delete(Seans entity)
        {
            db.Seanslar.Remove(entity);
            db.SaveChanges();
        }

        public IQueryable<Seans> Get(Expression<Func<Seans, bool>> exFnc)
        {
            return db.Seanslar.Where(exFnc);
        }

        public List<Seans> GetAll()
        {
            return db.Seanslar.ToList();
        }

        public Seans SelectById(int Id)
        {
            return db.Seanslar.FirstOrDefault(z => z.Id == Id);
           
        }

        public Seans Update(Seans entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return entity;
        }
    }
}
