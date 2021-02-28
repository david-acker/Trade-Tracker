namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactionsExport
{
    public class TransactionExportFileVm
    {
        public string TransactionExportFileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}