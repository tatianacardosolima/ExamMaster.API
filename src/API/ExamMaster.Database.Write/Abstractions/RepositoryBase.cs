using Common.Shared.Abstractions;
using Common.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using MockExam.Manage.Database.Write.Context;
using System.Linq.Expressions;

namespace MockExam.Manage.Database.Write.Abstractions
{
    public abstract class RepositoryBase<T, TId> : IRepository<T, TId>
        where T :EntityBase<TId>
        where TId : struct
    {
        private readonly MockExamContext _context;

        public RepositoryBase(MockExamContext context)
        {
            _context = context;
        }
        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public Task<bool> ExistsAsync(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().AnyAsync(expression);
        }

        public async Task<T> GetByIdAsync(TId id)
        {
            var entity = await _context.Set<T>()
                                   .Where(x => x.Id.Equals(id))
                                   .ToListAsync();

            return entity.FirstOrDefault();
        }

        public async Task InsertAsync(T entity)
        {
            await _context.Set<T>()
               .AddAsync(entity);
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>()
                .UpdateRange(entity);
        }
    }
}
