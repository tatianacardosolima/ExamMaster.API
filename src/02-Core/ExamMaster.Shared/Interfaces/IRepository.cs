using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Shared.Interfaces
{
    public interface IRepository<T, in TId> where T : IEntity where TId : struct
    {
        Task InsertAsync(T entity);

        Task InsertRangeAsync(List<T> entities);

        void Update(T entity);

        void UpdateRange(List<T> entities);

        void LogicalDelete(T obj);

        Task<T> GetByIdAsync(TId id);

        //Task<T> GetByUniqueIdAsync(Guid uniqueId);

        Task<List<T>> GetAllAsync();

        Task<List<T>> FindAsync(Expression<Func<T, bool>> expression);

        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
