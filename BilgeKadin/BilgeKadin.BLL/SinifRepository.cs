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
    public class SinifRepository : IRepository<Sinif>
    {
        BilgeKadinEntities db = SingletonInstancePerLifeTime.GetContextInstance();
        public Sinif Add(Sinif entity)
        {
            db.Sinifs.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public void Delete(Sinif entity)
        {
            db.Sinifs.Remove(entity);
            db.SaveChanges();

        }

        public IQueryable<Sinif> Get(Expression<Func<Sinif, bool>> exFnc)
        {
            return db.Sinifs.Where(exFnc);
        }

        public List<Sinif> GetAll()
        {
            return db.Sinifs.ToList();
        }

        public Sinif SelectById(int Id)
        {
            return db.Sinifs.FirstOrDefault(z => z.Id == Id);

        }

        public Sinif Update(Sinif entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return entity;
        }
    }
}
