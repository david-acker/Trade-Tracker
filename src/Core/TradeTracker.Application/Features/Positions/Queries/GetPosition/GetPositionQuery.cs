using MediatR;
using TradeTracker.Application.Requests;

namespace TradeTracker.Application.Features.Positions.Queries.GetPosition
{
    public class GetPositionQuery : AuthenticatedRequest, IRequest<PositionForReturnDto>
    {
        public string Symbol { get; set; }
    }
}
