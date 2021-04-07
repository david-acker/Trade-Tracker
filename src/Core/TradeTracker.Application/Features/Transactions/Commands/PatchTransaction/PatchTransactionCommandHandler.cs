using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Behaviors;
using TradeTracker.Application.Common.Exceptions;
using TradeTracker.Application.Common.Interfaces;
using TradeTracker.Application.Common.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Features.Transactions.Commands.UpdateTransaction;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;
using TradeTracker.Domain.Events;

namespace TradeTracker.Application.Features.Transactions.Commands.PatchTransaction
{
    public class PatchTransactionCommandHandler :
        ValidatableRequestBehavior<UpdateTransactionCommand>,
        IRequestHandler<PatchTransactionCommand>
    {
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;
        private readonly IEntityTagService _entityTagService;
         private readonly IMapper _mapper;
        public PatchTransactionCommandHandler(
            IAuthenticatedTransactionRepository authenticatedTransactionRepository,
            IEntityTagService entityTagService,
            IMapper mapper)
        {
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
            _entityTagService = entityTagService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(PatchTransactionCommand request, CancellationToken cancellationToken)
        {
            var existingTransaction = await _authenticatedTransactionRepository.GetByIdAsync(request.Id);

            if (existingTransaction == null)
            {
                throw new NotFoundException(nameof(Transaction), request.Id);
            }

            var ifMatchHeader = _entityTagService.GetEntityTagFromHeader();
            
            if (!String.IsNullOrWhiteSpace(ifMatchHeader))
            {
                var transactionForReturn = _mapper.Map<TransactionForReturnDto>(existingTransaction);

                if (ETagComparer.IsConflict(transactionForReturn, ifMatchHeader))
                {
                    throw new ResourceStateConflictException($"The representation of the {typeof(Transaction)} ({request.Id}) was changed.");
                }
            }       

            var updatedTransactionCommand = ApplyPatch(request, existingTransaction);
            await ValidateRequest(updatedTransactionCommand);

            var transaction = _mapper.Map<Transaction>(updatedTransactionCommand);
        
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