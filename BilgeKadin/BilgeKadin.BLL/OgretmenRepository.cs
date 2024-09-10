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
    public class OgretmenRepository : IRepository<Ogretmen>
    {
        BilgeKadinEntities db = SingletonInstancePerLifeTime.GetContextInstance();
        public Ogretmen Add(Ogretmen entity)
        {
            db.Ogretmens.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public void Delete(Ogretmen entity)
        {
            db.Ogretmens.Remove(entity);
            db.SaveChanges();
        }

        public IQueryable<Ogretmen> Get(Expression<Func<Ogretmen, bool>> exFnc)
        {
            return db.Ogretmens.Where(exFnc);

        }

        public List<Ogretmen> GetAll()
        {
            return db.Ogretmens.ToList();
        }

        public Ogretmen SelectById(int Id)
        {
            return db.Ogretmens.FirstOrDefault(z => z.Id == Id);
        }

        public Ogretmen Update(Ogretmen entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return entity;
        }
    }
}
