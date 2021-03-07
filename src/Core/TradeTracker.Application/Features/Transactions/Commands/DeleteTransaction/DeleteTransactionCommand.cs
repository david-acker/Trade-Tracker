using MediatR;
using System;

namespace TradeTracker.Application.Features.Transactions.Commands.DeleteTransaction
{
    public class DeleteTransactionCommand : IRequest
    {
        public Guid AccessKey { get; set; }
        public Guid TransactionId { get; set; }
    }
}