using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Models.Pagination;
using TradeTracker.Application.ResourceParameters.Paged;
using TradeTracker.Application.ResourceParameters.Unpaged;
using TradeTracker.Domain.Interfaces;
using TradeTracker.Persistence.Extensions;

namespace TradeTracker.Persistence.Repositories
{
    public class BaseRepository<TEntity, TPagedResourceParams, TUnpagedResourceParams> 
        : IAsyncRepository<TEntity, TPagedResourceParams, TUnpagedResourceParams> 
            where TEntity : class, IAuthorizableEntity
            where TPagedResourceParams : IPagedResourceParameters
            where TUnpagedResourceParams : IUnpagedResourceParameters
    {
        protected readonly TradeTrackerDbContext _context;

        public BaseRepository(TradeTrackerDbContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> GetByIdAsync(
            Guid id, 
            Guid accessKey)
        {
            return await _context.Set<TEntity>()
                .ForAccessKey(accessKey)
                .FirstOrDefaultAsync();
        }

        public virtual async Task<IReadOnlyList<TEntity>> ListAllAsync(
            Guid accessKey)
        {
            return await _context.Set<TEntity>()
                .ForAccessKey(accessKey)
                .ToListAsync();
        }

        public async virtual Task<PagedList<TEntity>> GetPagedResponseAsync(
            TPagedResourceParams parameters,
            Guid accessKey)
        {
            var query = _context.Set<TEntity>()
                .ForAccessKey(accessKey)
                .AsNoTracking();

            return await PagedList<TEntity>.CreateAsync(
                query, parameters.PageNumber, parameters.PageSize);
        }

        public async virtual Task<IEnumerable<TEntity>> GetUnpagedResponseAsync(
            TUnpagedResourceParams parameters,
            Guid accessKey)
        {
            return await _context.Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
            await _context.SaveChangesAsync();

            return entities;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
