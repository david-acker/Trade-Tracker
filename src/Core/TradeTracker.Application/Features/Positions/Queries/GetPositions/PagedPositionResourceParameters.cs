using System;
using System.Collections.Generic;

namespace TradeTracker.Application.Features.Positions.Queries.GetPositions
{
    public class PagedPositionsResourceParameters
    {
        public Guid AccessKey { get; set; }

        public string OrderBy { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public List<string> Including { get; set; }
        public List<string> Excluding { get; set; }

        public string Exposure { get; set; }
    }
}