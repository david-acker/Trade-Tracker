using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Features.Transactions.Commands.UpdateTransaction;
using TradeTracker.Application.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Requests;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;
using TradeTracker.Domain.Events;

namespace TradeTracker.Application.Features.Transactions.Commands.PatchTransaction
{
    public class PatchTransactionCommandHandler :
        ValidatableRequestHandler<UpdateTransactionCommand>,
        IRequestHandler<PatchTransactionCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;
        public PatchTransactionCommandHandler(
            IMapper mapper, 
            IAuthenticatedTransactionRepository authenticatedTransactionRepository)
        {
            _mapper = mapper;
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
        }

        public async Task<Unit> Handle(PatchTransactionCommand request, CancellationToken cancellationToken)
        {
            var existingTransaction = await _authenticatedTransactionRepository.GetByIdAsync(request.TransactionId);

            if (existingTransaction == null)
            {
                throw new NotFoundException(nameof(Transaction), request.TransactionId);
            }

            string symbolBeforeModification = existingTransaction.Symbol;
            TransactionType typeBeforeModification = existingTransaction.Type;
            decimal quantityBeforeModification = existingTransaction.Quantity;           

            var updatedTransactionCommand = ApplyPatch(request, existingTransaction);
            await ValidateRequest(updatedTransactionCommand);

            var transaction = _mapper.Map<Transaction>(updatedTransactionCommand);

            transaction.DomainEvents.Add(
                new TransactionModifiedEvent(
                    transaction.AccessKey,
                    transaction.TransactionId, 
                    symbolBeforeModification,
                    typeBeforeModification,
                    quantityBeforeModification));
        
            await _authenticatedTransactionRepository.UpdateAsync(transaction);

            return Unit.Value;
        }

        private UpdateTransactionCommand ApplyPatch(
            PatchTransactionCommand request, 
            Transaction existingTransaction)
        {
            var transactionForPatch = _mapper.Map<UpdateTransactionCommand>(existingTransaction);

            JsonPatchDocument<UpdateTransactionCommandBase> patchDocument = request.PatchDocument;
            patchDocument.ApplyTo(transactionForPatch);

            return transactionForPatch;
        }
    }
}