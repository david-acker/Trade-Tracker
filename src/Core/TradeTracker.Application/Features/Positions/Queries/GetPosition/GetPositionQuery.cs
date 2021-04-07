using MediatR;

namespace TradeTracker.Application.Features.Positions.Queries.GetPosition
{
    public class GetPositionQuery : IRequest<PositionForReturn>
    {
        public string Symbol { get; set; }
    }
}
