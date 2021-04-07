using MediatR;
using System.Collections.Generic;

namespace TradeTracker.Application.Features.Transactions.Commands.CreateTransactionCollection
{
    public class CreateTransactionCollectionCommand : IRequest<IEnumerable<TransactionForReturn>>
    {
        public IEnumerable<CreateTransactionCommandBase> Transactions { get; set; }
    }
}
