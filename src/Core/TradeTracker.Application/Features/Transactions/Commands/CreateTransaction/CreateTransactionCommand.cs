using MediatR;
using System;

namespace TradeTracker.Application.Features.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommand : TransactionForCreationDto, IRequest<TransactionDto>
    {
    }
}
