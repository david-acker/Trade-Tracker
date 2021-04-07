using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Interfaces.Persistence;
using TradeTracker.Application.Common.Models.Resources.Responses;
using TradeTracker.Application.ResourceParameters;
using TradeTracker.Domain.Common;
using TradeTracker.Persistence.Extensions;

namespace TradeTracker.Persistence.Repositories
{
    public class BaseRepository<TEntity, TPagedResourceParams, TUnpagedResourceParams> 
        : IAsyncRepository<TEntity, TPagedResourceParams, TUnpagedResourceParams> 
            where TEntity : BaseEntity
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
                .Where(t => t.Id == id)
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

        public async virtual Task<TEntity> AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async virtual Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
            await _context.SaveChangesAsync();

            return entities;
        }

        public async virtual Task UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async virtual Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
