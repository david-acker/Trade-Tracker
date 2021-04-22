using System.Collections.Generic;
using TradeTracker.Application.Common.Models.Resources.Responses;

namespace TradeTracker.Application.Features.Positions.Queries.GetPositions
{
    public class PagedPositionsBase
    {
        public PaginationMetadata Metadata { get; set; }

        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }

        public IEnumerable<PositionForReturn> Items { get; set; }
    }
}