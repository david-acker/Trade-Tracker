using System;
using MediatR;
using TradeTracker.Application.Requests;

namespace TradeTracker.Application.Features.Transactions.Queries.ExportTransactions
{
    public class ExportTransactionsQuery : AuthenticatedRequest, IRequest<TransactionsExportFileVm>
    {
    }
}
