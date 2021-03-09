using System;

namespace TradeTracker.Application.Features.Positions.Queries.GetPositions
{
    public class GetPositionsResourceParameters
    {
        public Guid AccessKey { get; set; } 

        public string OrderBy { get; set; } = "Quantity";

        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 25;

        public string Including { get; set; }
        public string Excluding { get; set; }

        public string Exposure { get; set; }
    }
}