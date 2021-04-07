using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TradeTracker.Application.Common.Interfaces.Infrastructure;
using TradeTracker.Application.Features.Transactions.Queries.ExportTransactions;

namespace TradeTracker.Infrastructure
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportTransactionsToCsv(List<TransactionForExport> transactionsForExport)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                csvWriter.WriteRecords(transactionsForExport);
            }

            return memoryStream.ToArray();
        }
    }
}
