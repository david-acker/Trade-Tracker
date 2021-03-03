using MediatR;

namespace TradeTracker.Application.Features.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommand : CreateTransactionCommandDto, IRequest<TransactionForReturnDto>
    {
        public string AccessKey { get; set; }
    }
}
