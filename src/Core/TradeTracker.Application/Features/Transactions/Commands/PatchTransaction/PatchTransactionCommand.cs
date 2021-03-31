using System;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace TradeTracker.Application.Features.Transactions.Commands.PatchTransaction
{
    public class PatchTransactionCommand : IRequest
    {
        public Guid TransactionId { get; set; }
        public JsonPatchDocument<UpdateTransactionCommandBase> PatchDocument { get; set; }
    }
}
