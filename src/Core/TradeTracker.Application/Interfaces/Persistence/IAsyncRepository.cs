using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TradeTracker.Application.Interfaces.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(string accessTag, Guid id);
        Task<IReadOnlyList<T>> ListAllAsync(string accessTag);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IReadOnlyList<T>> GetPagedReponseAsync(string accessTag, int page, int size);
    }
}
