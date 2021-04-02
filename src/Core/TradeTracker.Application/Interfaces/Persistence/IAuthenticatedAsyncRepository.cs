using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradeTracker.Application.Models.Pagination;
using TradeTracker.Application.ResourceParameters.Paged;
using TradeTracker.Application.ResourceParameters.Unpaged;
using TradeTracker.Domain.Interfaces;

namespace TradeTracker.Application.Interfaces.Persistence
{
    public interface IAuthenticatedAsyncRepository<TEntity, TPagedResourceParams, TUnpagedResourceParams> 
        where TEntity : class, IAuthorizableEntity
        where TPagedResourceParams : IPagedResourceParameters
        where TUnpagedResourceParams : IUnpagedResourceParameters
    {
        Task<TEntity> GetByIdAsync(
            Guid id);

        Task<TEntity> AddAsync(TEntity entity);

        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

        Task UpdateAsync(TEntity entity);
        
        Task DeleteAsync(TEntity entity);

        Task<PagedList<TEntity>> GetPagedResponseAsync(
            TPagedResourceParams parameters);

        Task<IEnumerable<TEntity>> GetUnpagedResponseAsync(
            TUnpagedResourceParams parameters);
    }
}
