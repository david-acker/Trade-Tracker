using System.Collections.Generic;
using TradeTracker.Business.AuxiliaryModels;

namespace TradeTracker.Api.DTOs
{
    public class LinkedPaginatedResult<TEntity> : PaginatedResult<TEntity>
    {
        public IEnumerable<Link> Links { get; set; }

        public LinkedPaginatedResult(IEnumerable<TEntity> results, PaginationMetadata metadata) : base(results, metadata)
        {
        }
    }
}
