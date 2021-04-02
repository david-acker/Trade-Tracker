using System;
using System.Linq;
using TradeTracker.Domain.Interfaces;

namespace TradeTracker.Persistence.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ForAccessKey<T>(this IQueryable<T> query, Guid accessKey)
            where T : IAuthorizableEntity
        {
            return query.Where(x => x.AccessKey == accessKey);
        }
    }
}