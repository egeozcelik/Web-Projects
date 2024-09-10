using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Data.Abstract
{
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        Task<T> GetAsync(Expression<Func<T,bool>> predicate,params Expression<Func<T, object>>[] includeProperties);// var kullanici = repo.GetAsync(m=> m.Id ==15);
        //params ve includeProperties kullanıcının yanında diğer bilgilerinin de yüklenmesini sağlar.
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, 
            params Expression<Func<T, object>>[] includeProperties);
        //predicate = null gelirse tüm makaleleri yükler,eğer null değilse filtreye uygun olan makaleyi yükler
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    }
}


