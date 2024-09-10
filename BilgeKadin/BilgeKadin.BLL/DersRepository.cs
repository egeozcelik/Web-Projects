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
    public class DersRepository : IRepository<Ders>
    {
        BilgeKadinEntities db = SingletonInstancePerLifeTime.GetContextInstance();
        public Ders Add(Ders entity)
        {
            db.Dersler.Add(entity);
            db.SaveChanges();
            return entity;

        }

        public void Delete(Ders entity)
        {
            db.Dersler.Remove(entity);
            db.SaveChanges();
            
        }

        public IQueryable<Ders> Get(Expression<Func<Ders, bool>> exFnc)
        {
           return db.Dersler.Where(exFnc);
        }

        public List<Ders> GetAll()
        {
            return db.Dersler.ToList();
        }

        public Ders SelectById(int Id)
        {
            return db.Dersler.FirstOrDefault(z => z.Id == Id);
        }

        public Ders Update(Ders entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return entity;
        }
    }
}
