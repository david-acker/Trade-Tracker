using TradeTracker.Application.Features.Transactions.Queries.GetTransactionsExport;
using System.Collections.Generic;

namespace TradeTracker.Application.Interfaces.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportTransactionsToCsv(List<TransactionForExportDto> transactionExportDtos);
    }
}