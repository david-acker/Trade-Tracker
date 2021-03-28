using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using TradeTracker.Application.Features.Transactions.Queries.ExportTransactions;
using TradeTracker.Application.Interfaces.Infrastructure;

namespace TradeTracker.Infrastructure
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportTransactionsToCsv(List<TransactionsForExportDto> transactionForExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                csvWriter.WriteRecords(transactionForExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
