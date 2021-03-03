using MediatR;
using System.Collections.Generic;

namespace TradeTracker.Application.Features.Transactions.Commands.CreateTransactionCollection
{
    public class CreateTransactionCollectionCommand : IRequest<IEnumerable<TransactionForReturnDto>>
    {
        public IEnumerable<TransactionForCreationCommandBase> Transactions { get; set; }
    }
}
