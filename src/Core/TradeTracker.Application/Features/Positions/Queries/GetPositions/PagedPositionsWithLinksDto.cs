using System.Collections.Generic;
using TradeTracker.Api.Models.Pagination;
using TradeTracker.Application.Models.Navigation;

namespace TradeTracker.Application.Features.Positions.Queries.GetPositions
{
    public class PagedPositionsWithLinksDto
    {
        public PaginationMetadata Metadata { get; set; }

        public IEnumerable<PositionForReturnWithLinksDto> Items { get; set; }

        public IEnumerable<LinkDto> Links { get; set; }
    }
}
