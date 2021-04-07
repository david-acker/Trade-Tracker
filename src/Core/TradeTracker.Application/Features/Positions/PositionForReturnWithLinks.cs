using System.Collections.Generic;
using TradeTracker.Application.Models.Common.Resources.Responses;

namespace TradeTracker.Application.Features.Positions
{
    public class PositionForReturnWithLinks : PositionForReturn
    {
        public IEnumerable<Link> Links { get; set; }
    }
}

