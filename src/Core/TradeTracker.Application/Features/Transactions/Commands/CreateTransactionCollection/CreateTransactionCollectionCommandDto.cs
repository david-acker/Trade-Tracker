using System.Collections.Generic;

namespace TradeTracker.Application.Features.Transactions.Commands.CreateTransactionCollection
{
    public class CreateTransactionCollectionCommandDto
    {
        public IEnumerable<TransactionForCreationDto> Transactions { get; set; }
    }
}
