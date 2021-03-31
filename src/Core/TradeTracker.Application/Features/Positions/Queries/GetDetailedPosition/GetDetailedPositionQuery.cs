using MediatR;

namespace TradeTracker.Application.Features.Positions.Queries.GetPosition
{
    public class GetDetailedPositionQuery : IRequest<DetailedPositionForReturnDto>
    {
        public string Symbol { get; set; }
    }
}
