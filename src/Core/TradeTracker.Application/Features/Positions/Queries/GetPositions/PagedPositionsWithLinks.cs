using System.Collections.Generic;
using TradeTracker.Application.Common.Models.Resources.Responses;
using TradeTracker.Application.Models.Common.Resources.Responses;

namespace TradeTracker.Application.Features.Positions.Queries.GetPositions
{
    public class PagedPositionsWithLinks
    {
        public PaginationMetadata Metadata { get; set; }

        public IEnumerable<PositionForReturnWithLinks> Items { get; set; }

        public IEnumerable<Link> Links { get; set; }
    }
}
