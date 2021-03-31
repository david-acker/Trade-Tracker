using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Interfaces;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Requests;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Enums;
using TradeTracker.Domain.Events;

namespace TradeTracker.Application.Features.Transactions.Commands.DeleteTransaction
{
    public class DeleteTransactionCommandHandler :
        IRequestHandler<DeleteTransactionCommand>
    {
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        
        public DeleteTransactionCommandHandler(
            ILoggedInUserService loggedInUserService,
            IMapper mapper, 
            ITransactionRepository transactionRepository)
        {
            _loggedInUserService = loggedInUserService;
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }

        public async Task<Unit> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            Guid userAccessKey = _loggedInUserService.AccessKey;
            
            if (userAccessKey == Guid.Empty)
            {
                throw new ValidationException("The current session has expired. Please reload and log back in.");
            }

            var transaction = await _transactionRepository.GetByIdAsync(userAccessKey, request.TransactionId);

            if (transaction == null)
            {
                throw new NotFoundException(nameof(Transaction), request.TransactionId);
            }

            string symbolBeforeDeletion = transaction.Symbol;
            TransactionType typeBeforeDeletion = transaction.Type;
            decimal quantityBeforeDeletion = transaction.Quantity;

            transaction.DomainEvents.Add(
                new TransactionDeletedEvent(
                    accessKey: transaction.AccessKey, 
                    symbolBeforeDeletion: symbolBeforeDeletion,
                    typeBeforeDeletion: typeBeforeDeletion,
                    quantityBeforeDeletion: quantityBeforeDeletion));

            await _transactionRepository.DeleteAsync(transaction);

            return Unit.Value;
        }
    }
}
