using MediatR;
using System;

namespace TradeTracker.Application.Features.Transactions.Commands.DeleteTransaction
{
    public class DeleteTransactionCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}