using System;
using MediatR;
using TradeTracker.Application.Requests;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class GetTransactionsQuery : AuthenticatedRequest, IRequest<PagedTransactionsBaseDto>
    {
        public string Order { get; set; } = "DateTime Descending";
        
        public string Type { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 25;

        public string Selection { get; set; }
        
        public string RangeStart { get; set; } = DateTime.MinValue.ToString(); 
        public string RangeEnd { get; set; } = DateTime.MaxValue.ToString();
    }
}
