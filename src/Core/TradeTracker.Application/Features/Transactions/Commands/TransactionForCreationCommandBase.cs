using System;

namespace TradeTracker.Application.Features.Transactions.Commands
{
    public class TransactionForCreationCommandBase : TransactionForCreationDto
    {
        public Guid AccessKey { get; set; }
    }
}
