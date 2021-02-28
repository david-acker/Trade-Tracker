using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Transactions.Commands.CreateTransactionCollection
{
    public class CreateTransactionCollectionCommandHandler 
        : IRequestHandler<CreateTransactionCollectionCommand, IEnumerable<TransactionDto>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public CreateTransactionCollectionCommandHandler(IMapper mapper, ITransactionRepository transactionRepository)
        {
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
            _transactionRepository = transactionRepository
                ?? throw new ArgumentNullException(nameof(transactionRepository));
        }

        public async Task<IEnumerable<TransactionDto>> Handle(
            CreateTransactionCollectionCommand request, 
            CancellationToken cancellationToken)
        {
            var validator = new CreateTransactionCollectionCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            
            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var transactionCollection = _mapper.Map<IEnumerable<Transaction>>(request);

            transactionCollection = await _transactionRepository.AddRangeAsync(transactionCollection);

            return _mapper.Map<IEnumerable<TransactionDto>>(transactionCollection);
        }
    }
}