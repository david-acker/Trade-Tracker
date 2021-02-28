using MediatR;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactionsExport
{
    public class GetTransactionsExportQuery : IRequest<TransactionExportFileVm>
    {
        public string AccessTag { get; set; }
    }
}
