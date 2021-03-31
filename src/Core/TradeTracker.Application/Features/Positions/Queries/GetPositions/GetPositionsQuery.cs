using MediatR;
using System.Collections.Generic;
using TradeTracker.Application.Requests;

namespace TradeTracker.Application.Features.Positions.Queries.GetPositions
{
    public class GetPositionsQuery : AuthenticatedRequest, IRequest<PagedPositionsBaseDto>
    {
        public string Order { get; set; } = "Quantity Descending";

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 25;

        public string Selection { get; set; } 

        public string Exposure { get; set; }
    }
}
