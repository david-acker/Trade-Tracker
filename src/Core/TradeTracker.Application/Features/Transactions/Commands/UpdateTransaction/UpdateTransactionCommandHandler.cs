using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Behaviors;
using TradeTracker.Application.Common.Exceptions;
using TradeTracker.Application.Common.Interfaces;
using TradeTracker.Application.Common.Interfaces.Persistence.Transactions;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;
using TradeTracker.Domain.Events;

namespace TradeTracker.Application.Features.Transactions.Commands.UpdateTransaction
{
    public class UpdateTransactionCommandHandler : 
        ValidatableRequestBehavior<UpdateTransactionCommand>,
        IRequestHandler<UpdateTransactionCommand>
    {
       
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;
        private readonly IEntityTagService _entityTagService;
        private readonly IMapper _mapper;
        public UpdateTransactionCommandHandler(
            IAuthenticatedTransactionRepository authenticatedTransactionRepository,
            IEntityTagService entityTagService,
            IMapper mapper)
        {
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
            _entityTagService = entityTagService;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var transaction = await _authenticatedTransactionRepository.GetByIdAsync(request.TransactionId);

            if (transaction == null)
            {
                throw new NotFoundException(nameof(Transaction), request.TransactionId);
            }

            var ifMatchHeader = _entityTagService.GetEntityTagFromHeader();

            if (!String.IsNullOrWhiteSpace(ifMatchHeader))
            {
                var transactionForReturn = _mapper.Map<TransactionForReturnDto>(transaction);

                if (ETagComparer.IsConflict(transactionForReturn, ifMatchHeader))
                {
                    throw new ResourceStateConflictException(nameof(Transaction), request.TransactionId);
                }
            }

            string symbolBeforeModification = transaction.Symbol;
            TransactionType typeBeforeModification = transaction.Type;
            decimal quantityBeforeModification = transaction.Quantity;

            _mapper.Map(request, transaction, typeof(UpdateTransactionCommand), typeof(Transaction));

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
    }
}