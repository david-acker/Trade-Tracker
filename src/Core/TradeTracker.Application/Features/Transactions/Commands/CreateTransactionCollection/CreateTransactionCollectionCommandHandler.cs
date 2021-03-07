using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Events;

namespace TradeTracker.Application.Features.Transactions.Commands.CreateTransactionCollection
{
    public class CreateTransactionCollectionCommandHandler 
        : IRequestHandler<CreateTransactionCollectionCommand, IEnumerable<TransactionForReturnDto>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public CreateTransactionCollectionCommandHandler(IMapper mapper, ITransactionRepository transactionRepository)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<TransactionForReturnDto>> Handle(
            CreateTransactionCollectionCommand request, 
            CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var transactionCollection = _mapper.Map<IEnumerable<Transaction>>(request.Transactions);

            var lastTransaction = transactionCollection.Last();
            lastTransaction.DomainEvents.Add(
                new TransactionCollectionCreatedEvent(transactionCollection));

            transactionCollection = await _transactionRepository.AddRangeAsync(transactionCollection);

            return _mapper.Map<IEnumerable<TransactionForReturnDto>>(transactionCollection);
        }

        public async Task ValidateRequest(CreateTransactionCollectionCommand request)
        {
            var validator = new CreateTransactionCollectionCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            
            if (validationResult.Errors.Count > 0)
            {
                throw new Exceptions.ValidationException(validationResult);
            }
        }
    }
}