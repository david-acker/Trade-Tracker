using MediatR;

namespace TradeTracker.Application.Features.Positions.Queries.GetPosition
{
    public class GetPositionQuery : IRequest<PositionForReturnDto>
    {
        public string Symbol { get; set; }
    }
}
