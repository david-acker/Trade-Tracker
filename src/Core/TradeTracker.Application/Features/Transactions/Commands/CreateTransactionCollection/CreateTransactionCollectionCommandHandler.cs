using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Interfaces;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Requests;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Events;

namespace TradeTracker.Application.Features.Transactions.Commands.CreateTransactionCollection
{
    public class CreateTransactionCollectionCommandHandler :
        ValidatableRequestHandler<CreateTransactionCollectionCommand>,
        IRequestHandler<CreateTransactionCollectionCommand, IEnumerable<TransactionForReturnDto>>
    {

        private readonly ILoggedInUserService _loggedInUserService;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public CreateTransactionCollectionCommandHandler(
            ILoggedInUserService loggedInUserService,
            IMapper mapper, 
            ITransactionRepository transactionRepository)
        {
            _loggedInUserService = loggedInUserService;
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<TransactionForReturnDto>> Handle(
            CreateTransactionCollectionCommand request, 
            CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            Guid userAccessKey = _loggedInUserService.AccessKey;
            
            if (userAccessKey == Guid.Empty)
            {
                throw new ValidationException("The current session has expired. Please reload and log back in.");
            }

            var transactionCollection = _mapper.Map<IEnumerable<Transaction>>(request.Transactions);

            var lastTransaction = transactionCollection.Last();
            lastTransaction.DomainEvents.Add(
                new TransactionCollectionCreatedEvent(transactionCollection));

            transactionCollection = await _transactionRepository.AddRangeAsync(transactionCollection);

            return _mapper.Map<IEnumerable<TransactionForReturnDto>>(transactionCollection);
        }
    }
}