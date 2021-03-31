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
using TradeTracker.Domain.Events;

namespace TradeTracker.Application.Features.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommandHandler : 
        ValidatableRequestHandler<CreateTransactionCommand>,
        IRequestHandler<CreateTransactionCommand, TransactionForReturnDto>
    {
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public CreateTransactionCommandHandler(
            ILoggedInUserService loggedInUserService,
            IMapper mapper, 
            ITransactionRepository transactionRepository)
        {
            _loggedInUserService = loggedInUserService;
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }

        public async Task<TransactionForReturnDto> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            Guid userAccessKey = _loggedInUserService.AccessKey;
            
            if (userAccessKey == Guid.Empty)
            {
                throw new ValidationException("The current session has expired. Please reload and log back in.");
            }

            var transaction = _mapper.Map<Transaction>(request);

            transaction.DomainEvents.Add(
                new TransactionCreatedEvent(
                    accessKey: transaction.AccessKey, 
                    transactionId: transaction.TransactionId));

            transaction = await _transactionRepository.AddAsync(transaction);

            return _mapper.Map<TransactionForReturnDto>(transaction);
        }
    }
}