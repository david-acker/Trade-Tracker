using System.Collections.Generic;
using TradeTracker.Application.Models.Common.Resources.Responses;

namespace TradeTracker.Application.Features.Positions
{
    public class DetailedPositionForReturnWithLinks : DetailedPositionForReturn
    {
        public IEnumerable<Link> Links { get; set; }
    }
}

