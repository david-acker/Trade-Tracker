using MediatR;
using System;

namespace TradeTracker.Application.Features.Positions.Queries.GetPosition
{
    public class GetPositionQuery : IRequest<PositionForReturnDto>
    {
        public Guid AccessKey { get; set; }
        public string Symbol { get; set; }
    }
}
