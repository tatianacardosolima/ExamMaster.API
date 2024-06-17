using ExamMaster.Database.Read.Contexts;
using ExamMaster.Shared.Abstractions;
using ExamMaster.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExamMaster.Database.Read.Abstractions
{
    public abstract class RepositoryBase<T, TId> : IRepository<T, TId> where T : EntityBase
        where TId : struct
    {
        private readonly ExamMasterContext _context;

        public RepositoryBase(ExamMasterContext context)
        {
            _context = context;
        }


        public virtual async Task<T> Get(TId id)
        {
            var entity = await _context.Set<T>()
                                    .Where(x => x.Id.Equals(id))
                                    .ToListAsync();

            return entity.FirstOrDefault();
        }

        public virtual async Task<List<T>> Get()
        {
            return await _context.Set<T>()
                                 .AsNoTracking()
                                 .ToListAsync();
        }


        public Task InsertAsync(T entity)
        {

            return _context.Set<T>()
                .AddAsync(entity)
                .AsTask();
        }

        public Task InsertRangeAsync(List<T> entities)
        {
            return _context.Set<T>()
                .AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            _context.Set<T>()
                .Update(entity);
        }

        public void UpdateRange(List<T> entities)
        {
            _context.Set<T>()
                .UpdateRange(entities);
        }

        public void LogicalDeleteAsync(T entity)
        {
            //entity.IsDeleted = true;
            _context.Set<T>()
                .Update(entity);
        }

        public void LogicalDelete(T entity)
        {
            //entity.IsDeleted = true;
            _context.Set<T>()
                .Update(entity);
        }

        public async Task<T> GetByIdAsync(TId id)
        {
            return await _context.Set<T>()
               .FindAsync(id);
        }

        public Task<List<T>> GetAllAsync()
        {
            return _context.Set<T>()
               .ToListAsync();
        }

       
        public Task<List<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>()
               .Where(expression)
               .ToListAsync();
        }

        public Task<bool> ExistsAsync(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().AnyAsync(expression);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

       
    }
}
