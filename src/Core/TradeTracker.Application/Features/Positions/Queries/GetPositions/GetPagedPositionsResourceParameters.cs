using System;

namespace TradeTracker.Application.Features.Positions.Queries.GetPositions
{
    public class GetPagedPositionsResourceParameters
    {
        public Guid AccessKey { get; set; } 

        public string Order { get; set; } = "Quantity+desc";

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 25;

        public string Including { get; set; }
        public string Excluding { get; set; }

        public string Exposure { get; set; }
    }
}