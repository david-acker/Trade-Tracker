using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Events;

namespace TradeTracker.Application.Features.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, TransactionForReturnDto>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public CreateTransactionCommandHandler(IMapper mapper, ITransactionRepository transactionRepository)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }

        public async Task<TransactionForReturnDto> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var transaction = _mapper.Map<Transaction>(request);

            transaction.DomainEvents.Add(
                new TransactionCreatedEvent(
                    accessKey: transaction.AccessKey, 
                    transactionId: transaction.TransactionId));

            transaction = await _transactionRepository.AddAsync(transaction);

            return _mapper.Map<TransactionForReturnDto>(transaction);
        }

        private async Task ValidateRequest(CreateTransactionCommand request)
        {
            var validator = new CreateTransactionCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }
        }
    }
}