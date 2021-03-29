using System;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using TradeTracker.Application.Requests;

namespace TradeTracker.Application.Features.Transactions.Commands.PatchTransaction
{
    public class PatchTransactionCommand : AuthenticatedRequest, IRequest
    {
        public Guid TransactionId { get; set; }
        public JsonPatchDocument<UpdateTransactionCommandBase> PatchDocument { get; set; }
    }
}
