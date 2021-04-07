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

            var transaction = await _authenticatedTransactionRepository.GetByIdAsync(request.Id);

            if (transaction == null)
            {
                throw new NotFoundException(nameof(Transaction), request.Id);
            }

            var ifMatchHeader = _entityTagService.GetEntityTagFromHeader();

            if (!String.IsNullOrWhiteSpace(ifMatchHeader))
            {
                var transactionForReturn = _mapper.Map<TransactionForReturn>(transaction);

                if (ETagComparer.IsConflict(transactionForReturn, ifMatchHeader))
                {
                    throw new ResourceStateConflictException(nameof(Transaction), request.Id);
                }
            }

            _mapper.Map(request, transaction, typeof(UpdateTransactionCommand), typeof(Transaction));

            await _authenticatedTransactionRepository.UpdateAsync(transaction);

            return Unit.Value;
        }
    }
}