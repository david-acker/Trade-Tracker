using MediatR;

namespace TradeTracker.Application.Features.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommand : TransactionForCreationCommandBase, IRequest<TransactionForReturnDto>
    {
    }
}
