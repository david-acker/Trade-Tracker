using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Requests;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;
using TradeTracker.Domain.Events;

namespace TradeTracker.Application.Features.Transactions.Commands.UpdateTransaction
{
    public class UpdateTransactionCommandHandler : 
        ValidatableRequestHandler<UpdateTransactionCommand>,
        IRequestHandler<UpdateTransactionCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;
        public UpdateTransactionCommandHandler(
            IMapper mapper, 
            IAuthenticatedTransactionRepository authenticatedTransactionRepository)
        {
            _mapper = mapper;
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
        }

        public async Task<Unit> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var transaction = await _authenticatedTransactionRepository.GetByIdAsync(request.TransactionId);

            if (transaction == null)
            {
                throw new NotFoundException(nameof(Transaction), request.TransactionId);
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