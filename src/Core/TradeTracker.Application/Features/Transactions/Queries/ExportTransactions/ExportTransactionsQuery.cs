using System;
using MediatR;

namespace TradeTracker.Application.Features.Transactions.Queries.ExportTransactions
{
    public class ExportTransactionsQuery : IRequest<TransactionsExportFileVm>
    {
        public string OrderBy { get; set; } = "DateTime Descending";

        public string TransactionType { get; set; }

        public string SymbolSelection { get; set; }
        
        public string RangeStart { get; set; } = DateTime.MinValue.ToString(); 
        public string RangeEnd { get; set; } = DateTime.MaxValue.ToString();
    }
}
