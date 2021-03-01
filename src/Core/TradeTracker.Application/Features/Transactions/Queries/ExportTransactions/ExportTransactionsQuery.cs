using MediatR;

namespace TradeTracker.Application.Features.Transactions.Queries.ExportTransactions
{
    public class ExportTransactionsQuery : IRequest<TransactionsExportFileVm>
    {
        public string AccessKey { get; set; }
    }
}
