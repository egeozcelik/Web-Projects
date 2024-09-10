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
    public class OgrenciRepository : IRepository<Ogrenci>
    {
        BilgeKadinEntities db = SingletonInstancePerLifeTime.GetContextInstance();
        public Ogrenci Add(Ogrenci entity)
        {
            db.Ogrencis.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public void Delete(Ogrenci entity)
        {
            db.Ogrencis.Remove(entity);
            db.SaveChanges();
        }

        public IQueryable<Ogrenci> Get(Expression<Func<Ogrenci, bool>> exFnc)
        {
            return db.Ogrencis.Where(exFnc);
        }

        public List<Ogrenci> GetAll()
        {
            return db.Ogrencis.ToList();
        }

        public Ogrenci SelectById(int Id)
        {
            return db.Ogrencis.FirstOrDefault(z => z.Id == Id);
        }

        public Ogrenci Update(Ogrenci entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return entity;
        }
    }
}
