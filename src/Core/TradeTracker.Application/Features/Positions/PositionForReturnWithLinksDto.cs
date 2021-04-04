using System.Collections.Generic;
using TradeTracker.Application.Models.Common.Resources.Responses;

namespace TradeTracker.Application.Features.Positions
{
    public class PositionForReturnWithLinksDto : PositionForReturnDto
    {
        public IEnumerable<LinkDto> Links { get; set; }
    }
}

