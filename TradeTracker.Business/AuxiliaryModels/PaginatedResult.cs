using System.Collections.Generic;

namespace TradeTracker.Business.AuxiliaryModels
{
    public class PaginatedResult<TEntity>
    {
        public IEnumerable<TEntity> Results { get; set; }
        public PaginationMetadata Metadata { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }

        public PaginatedResult(IEnumerable<TEntity> results, PaginationMetadata metadata)
        {
            Results = results;
            Metadata = metadata;
            HasPrevious = (metadata.Page > 0);
            HasPrevious = (metadata.Page < metadata.TotalPages);
        }
    }

    public class PaginationMetadata
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecordCount { get; set; }
    }
}
