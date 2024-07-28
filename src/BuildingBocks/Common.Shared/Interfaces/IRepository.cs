using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Common.Shared.Abstractions;

namespace Common.Shared.Interfaces
{
    public interface IRepository<T, in TId>
           where T : IEntity<TId>
           where TId : struct           
    {
        Task InsertAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> GetByIdAsync(TId id);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);
        Task SaveChangesAsync();
    }
}
