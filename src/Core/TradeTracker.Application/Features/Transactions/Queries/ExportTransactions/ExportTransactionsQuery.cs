using MediatR;

namespace TradeTracker.Application.Features.Transactions.Queries.ExportTransactions
{
    public class ExportTransactionsQuery : IRequest<TransactionsForExportFileVm>
    {
        public string OrderBy { get; set; }

        public string TransactionType { get; set; }

        public string SymbolSelection { get; set; }
        
        public string RangeStart { get; set; }
        public string RangeEnd { get; set; }
    }
}
