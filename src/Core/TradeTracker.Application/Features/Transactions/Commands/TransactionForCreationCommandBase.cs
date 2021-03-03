namespace TradeTracker.Application.Features.Transactions.Commands
{
    public class TransactionForCreationCommandBase : TransactionForCreationDto
    {
        public string AccessKey { get; set; }
    }
}
