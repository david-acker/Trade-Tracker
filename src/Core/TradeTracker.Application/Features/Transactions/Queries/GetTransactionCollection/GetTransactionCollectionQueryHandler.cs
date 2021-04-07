using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Behaviors;
using TradeTracker.Application.Common.Exceptions;
using TradeTracker.Application.Common.Interfaces.Persistence.Transactions;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactionCollection
{
    public class GetTransactionCollectionQueryHandler :
        ValidatableRequestBehavior<GetTransactionCollectionQuery>,
        IRequestHandler<GetTransactionCollectionQuery, IEnumerable<TransactionForReturnDto>>
    {
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;
        private readonly IMapper _mapper;
        
        public GetTransactionCollectionQueryHandler(
            IAuthenticatedTransactionRepository authenticatedTransactionRepository,
            IMapper mapper)
        {
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransactionForReturnDto>> Handle(GetTransactionCollectionQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var transactionCollection = await _authenticatedTransactionRepository
                .GetTransactionCollectionByIdsAsync(request.Ids);
            
            if (transactionCollection.Count() != request.Ids.Count())
            {
                var transactionIdsNotFound = GetTransactionIdsNotFound(transactionCollection, request.Ids);

                throw new NotFoundException(nameof(Transaction), transactionIdsNotFound);
            }

            var transactionCollectionDto = _mapper.Map<IEnumerable<TransactionForReturnDto>>(transactionCollection);

            return transactionCollectionDto;
        }

        private List<string> GetTransactionIdsNotFound(
            IEnumerable<Transaction> transactionCollection, 
            IEnumerable<Guid> requestedTransactionIds)
        {
            var idsFound = transactionCollection
                .Select(t => t.Id)
                .ToList();
            
            var idsNotFound = requestedTransactionIds
                .Where(t => !idsFound.Contains(t))
                .OrderBy(t => t)
                .Select(t => t.ToString())
                .ToList();
            
            return idsNotFound;
        }
    }
}
