using System.Collections.Generic;
using TradeTracker.Application.Models.Common.Resources.Responses;

namespace TradeTracker.Application.Features.Positions
{
    public class DetailedPositionForReturnWithLinksDto : DetailedPositionForReturnDto
    {
        public IEnumerable<LinkDto> Links { get; set; }
    }
}

