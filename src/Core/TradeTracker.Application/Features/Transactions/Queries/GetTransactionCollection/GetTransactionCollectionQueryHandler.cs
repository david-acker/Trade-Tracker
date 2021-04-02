using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Requests;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactionCollection
{
    public class GetTransactionCollectionQueryHandler :
        ValidatableRequestHandler<GetTransactionCollectionQuery>,
        IRequestHandler<GetTransactionCollectionQuery, IEnumerable<TransactionForReturnDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;
        public GetTransactionCollectionQueryHandler(
            IMapper mapper, 
            IAuthenticatedTransactionRepository authenticatedTransactionRepository)
        {
            _mapper = mapper;
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
        }

        public async Task<IEnumerable<TransactionForReturnDto>> Handle(GetTransactionCollectionQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var transactionCollection = await _authenticatedTransactionRepository
                .GetTransactionCollectionByIdsAsync(request.TransactionIds);
            
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
    }
}
