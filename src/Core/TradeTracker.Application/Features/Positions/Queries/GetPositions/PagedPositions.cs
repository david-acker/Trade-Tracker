using System.Collections.Generic;

namespace TradeTracker.Application.Features.Positions.Queries.GetPositions
{
    public class PagedPositions
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }

        public IEnumerable<PositionForReturn> Items { get; set; }
    }
}
