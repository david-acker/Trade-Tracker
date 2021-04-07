namespace TradeTracker.Application.Features.Transactions.Queries.ExportTransactions
{
    public class TransactionsForExportFileVm
    {
        public string TransactionsExportFileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}