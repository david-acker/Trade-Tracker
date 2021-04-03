using System.Collections.Generic;
using TradeTracker.Application.Features.Transactions.Queries.ExportTransactions;

namespace TradeTracker.Application.Common.Interfaces.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportTransactionsToCsv(List<TransactionsForExportDto> transactionExportDtos);
    }
}