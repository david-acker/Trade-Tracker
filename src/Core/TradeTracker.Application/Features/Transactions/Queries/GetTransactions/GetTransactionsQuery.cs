using System;
using MediatR;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class GetTransactionsQuery : IRequest<PagedTransactionsBaseDto>
    {
        public string OrderBy { get; set; } = "DateTime Descending";
        
        public string TransactionType { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 25;

        public string SymbolSelection { get; set; }
        
        public string RangeStart { get; set; } = DateTime.MinValue.ToString(); 
        public string RangeEnd { get; set; } = DateTime.MaxValue.ToString();
    }
}
