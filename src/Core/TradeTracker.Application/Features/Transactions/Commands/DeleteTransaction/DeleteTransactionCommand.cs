using MediatR;
using System;
using TradeTracker.Application.Requests;

namespace TradeTracker.Application.Features.Transactions.Commands.DeleteTransaction
{
    public class DeleteTransactionCommand : AuthenticatedRequest, IRequest
    {
        public Guid TransactionId { get; set; }
    }
}