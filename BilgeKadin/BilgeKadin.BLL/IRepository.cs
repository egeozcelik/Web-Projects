using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BilgeKadin.BLL
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        List<T> GetAll();
        IQueryable<T> Get(Expression<Func<T, bool>> exFnc);
        T SelectById(int Id);
    }
}
