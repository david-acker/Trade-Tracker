using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactionCollection
{
    public class GetTransactionCollectionQueryHandler 
        : IRequestHandler<GetTransactionCollectionQuery, IEnumerable<TransactionForReturnDto>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetTransactionCollectionQueryHandler(IMapper mapper, ITransactionRepository transactionRepository)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }

        public async Task<IEnumerable<TransactionForReturnDto>> Handle(GetTransactionCollectionQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var transactionCollection = await _transactionRepository.GetTransactionCollectionByIdsAsync(request.AccessKey, request.TransactionIds);
            
            if (transactionCollection.Count() != request.TransactionIds.Count())
            {
                var transactionIdsFound = transactionCollection
                    .Select(t => t.TransactionId)
                    .ToList();

                var transactionIdsNotFound = request.TransactionIds
                    .Where(t => !transactionIdsFound.Contains(t))
                    .OrderBy(t => t)
                    .Select(t => t.ToString())
                    .ToList();

                throw new NotFoundException(nameof(Transaction), transactionIdsNotFound);
            }

            var transactionCollectionDto = _mapper.Map<IEnumerable<TransactionForReturnDto>>(transactionCollection);

            return transactionCollectionDto;
        }

        private async Task ValidateRequest(GetTransactionCollectionQuery request)
        {
            var validator = new GetTransactionCollectionQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }  
        }
    }
}
