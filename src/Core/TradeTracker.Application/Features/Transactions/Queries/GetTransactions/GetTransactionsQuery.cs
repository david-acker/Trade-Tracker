using MediatR;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class GetTransactionsQuery : IRequest<PagedTransactionsBase>
    {
        public string OrderBy { get; set; }
        
        public string TransactionType { get; set; }

        public int PageNumber { get; set; } 
        public int PageSize { get; set; }

        public string SymbolSelection { get; set; }
        
        public string RangeStart { get; set; }
        public string RangeEnd { get; set; }
    }
}
