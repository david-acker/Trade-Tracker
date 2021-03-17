using System.Collections.Generic;
using TradeTracker.Application.Models.Navigation;

namespace TradeTracker.Application.Features.Positions
{
    public class PositionForReturnWithLinksDto : PositionForReturnDto
    {
        public IEnumerable<LinkDto> Links { get; set; }
    }
}

