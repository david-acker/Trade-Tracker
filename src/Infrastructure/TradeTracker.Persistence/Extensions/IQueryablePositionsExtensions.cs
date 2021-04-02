using System.Linq;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Persistence.Extensions
{
    public static class IQueryablePositionsExtensions
    {
        public static IQueryable<T> ForExposureType<T>(this IQueryable<T> query, string exposureType)
            where T : Position
        {
            switch (exposureType)
            {
                case "Long":
                    query = query.Where(t => t.Exposure == "Long");
                    break;
                
                case "Short":
                    query = query.Where(t => t.Exposure == "Short");
                    break;

                default:
                    break;
            }

            return query;
        }
    }
}
