using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeTracker.Application.Interfaces.Persistence;

namespace TradeTracker.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly TradeTrackerDbContext _dbContext;

        public BaseRepository(TradeTrackerDbContext dbContext)
        {
            _dbContext = dbContext 
                ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public virtual async Task<T> GetByIdAsync(string accessTag, Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public virtual async Task<IReadOnlyList<T>> ListAllAsync(string accessTag)
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async virtual Task<IReadOnlyList<T>> GetPagedReponseAsync(string accessTag, int pageNumber, int pageSize)
        {
            return await _dbContext.Set<T>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);
            await _dbContext.SaveChangesAsync();

            return entities;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
