using EgeBlogSite.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgeBlogSite.CORE.UnitOfWork
{
   public class UnitOfWork
    {
        public readonly BlogSiteEntities db;
        public UnitOfWork()
        {
            this.db = SingletonObject.SingletonDB.GetInstance();
        }
        public void Save()
        {
            try
            {
                using(var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
