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
    public class SinifDersRepository : IRepository<SinifDers>
    {
        BilgeKadinEntities db = SingletonInstancePerLifeTime.GetContextInstance();
        public SinifDers Add(SinifDers entity)
        {
            db.SinifDersler.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public void Delete(SinifDers entity)
        {
            SinifDers sd = db.SinifDersler.FirstOrDefault(z => z.Id == entity.Id);
            db.SinifDersler.Remove(sd);
            db.SaveChanges();
        }

        public IQueryable<SinifDers> Get(Expression<Func<SinifDers, bool>> exFnc)
        {
            return db.SinifDersler.Where(exFnc);
        }

        public List<SinifDers> GetAll()
        {
            return db.SinifDersler.ToList();
        }

        public SinifDers SelectById(int Id)
        {
            return db.SinifDersler.FirstOrDefault(z => z.Id == Id);
        }

        public SinifDers Update(SinifDers entity)
        {
           // var dbentity = db.SinifDersler.FirstOrDefault(z => z.Id == entity.Id);
           // dbentity.Ogrencis = entity.Ogrencis;
           // dbentity.Ogretmen = entity.Ogretmen;
           // dbentity.Seans = entity.Seans;
           // dbentity.Sinif = entity.Sinif;
           // dbentity.Ders = entity.Ders;
           db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
           db.SaveChanges();
            return entity;
        }
    }
}
