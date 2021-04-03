using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Models.Resources.Responses;
using TradeTracker.Application.ResourceParameters;
using TradeTracker.Domain.Interfaces;

namespace TradeTracker.Application.Common.Interfaces.Persistence
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
