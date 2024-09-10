using BilgeKoleji.Core.Data.Repositories;
using BilgeKoleji.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeKoleji.Core.Data.UnitOfWork
{
   public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : Entity<int>;

        int SaveChanges();
    }
}
