using System;
using TradeTracker.Api.Models.Querying;

namespace TradeTracker.Application.Features.Positions.Queries.GetPositions
{
    public class PagedPositionsResourceParameters
    {
        public SortOrder SortOrder { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public Selection Selection { get; set; }

        public string Exposure { get; set; }
    }
}