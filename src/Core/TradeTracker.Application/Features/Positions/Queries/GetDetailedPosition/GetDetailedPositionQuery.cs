using MediatR;

namespace TradeTracker.Application.Features.Positions.Queries.GetPosition
{
    public class GetDetailedPositionQuery : IRequest<DetailedPositionForReturn>
    {
        public string Symbol { get; set; }
    }
}
