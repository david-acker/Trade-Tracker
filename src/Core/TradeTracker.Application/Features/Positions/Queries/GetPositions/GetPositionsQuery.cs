using MediatR;

namespace TradeTracker.Application.Features.Positions.Queries.GetPositions
{
    public class GetPositionsQuery : IRequest<PagedPositionsBase>
    {
        public string OrderBy { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 25;
        public string SymbolSelection { get; set; }
        public string ExposureType { get; set; }
    }
}
