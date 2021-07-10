using System.Collections.Generic;
using TradeTracker.Business.AuxiliaryModels;

namespace TradeTracker.Api.DTOs.Position
{
    public class PositionFilterDto
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 25;
        public char? PositionType { get; set; }
        public string OrderByField { get; set; }
        public char? OrderByDirection { get; set; }
    }

    public class LinkedPositionDto
    {
        public PositionDto Position { get; set; }
        public IEnumerable<Link> Links { get; set; }
    }
}
