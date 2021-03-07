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
        protected readonly TradeTrackerDbContext _context;

        public BaseRepository(TradeTrackerDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> GetByIdAsync(Guid accessKey, Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IReadOnlyList<T>> ListAllAsync(Guid accessKey)
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async virtual Task<IReadOnlyList<T>> GetPagedReponseAsync(Guid accessKey, int pageNumber, int pageSize)
        {
            return await _context.Set<T>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            await _context.SaveChangesAsync();

            return entities;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
