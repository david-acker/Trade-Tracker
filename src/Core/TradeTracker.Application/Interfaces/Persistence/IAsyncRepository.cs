using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TradeTracker.Application.Interfaces.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid AccessKey, Guid id);

        Task<IReadOnlyList<T>> ListAllAsync(Guid AccessKey);

        Task<T> AddAsync(T entity);

        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        Task UpdateAsync(T entity);
        
        Task DeleteAsync(T entity);

        Task<IReadOnlyList<T>> GetPagedReponseAsync(Guid AccessKey, int page, int size);
    }
}
