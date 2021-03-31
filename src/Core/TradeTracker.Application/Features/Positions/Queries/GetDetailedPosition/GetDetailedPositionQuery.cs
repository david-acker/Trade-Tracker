using MediatR;
using TradeTracker.Application.Requests;

namespace TradeTracker.Application.Features.Positions.Queries.GetPosition
{
    public class GetDetailedPositionQuery : AuthenticatedRequest, IRequest<DetailedPositionForReturnDto>
    {
        public string Symbol { get; set; }
    }
}
