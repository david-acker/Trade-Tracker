using System.Collections.Generic;
using TradeTracker.Application.Common.Models.Resources.Responses;
using TradeTracker.Application.Models.Common.Resources.Responses;

namespace TradeTracker.Application.Features.Positions.Queries.GetPositions
{
    public class PagedPositionsWithLinksDto
    {
        public PaginationMetadata Metadata { get; set; }

        public IEnumerable<PositionForReturnWithLinksDto> Items { get; set; }

        public IEnumerable<LinkDto> Links { get; set; }
    }
}
