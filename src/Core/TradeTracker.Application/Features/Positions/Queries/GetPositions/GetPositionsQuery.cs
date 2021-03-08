using MediatR;
using System;
using System.Collections.Generic;

namespace TradeTracker.Application.Features.Positions.Queries.GetPositions
{
    public class GetPositionsQuery : IRequest<IEnumerable<PositionForReturnDto>>
    {
        public Guid AccessKey { get; set; }
    }
}
