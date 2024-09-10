using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgeBlogSite.BLL
{
   public interface IRepository<T>
    {
        List<T> GetAll();
        T Add(T entity);
        T Delete(T entity);
        void Update(T entity);
        T GetById(int Id);

    }
}
