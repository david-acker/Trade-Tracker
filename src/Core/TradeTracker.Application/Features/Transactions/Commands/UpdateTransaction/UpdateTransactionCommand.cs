using System;
using MediatR;

namespace TradeTracker.Application.Features.Transactions.Commands.UpdateTransaction
{
    public class UpdateTransactionCommand : UpdateTransactionCommandBase, IRequest
    {
        public Guid Id { get; set; }
    }
}
