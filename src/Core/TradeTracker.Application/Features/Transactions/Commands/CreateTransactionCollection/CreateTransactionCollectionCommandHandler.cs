using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Interfaces;
using TradeTracker.Application.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Requests;
using TradeTracker.Domain.Entities;
using TradeTracker.Domain.Events;

namespace TradeTracker.Application.Features.Transactions.Commands.CreateTransactionCollection
{
    public class CreateTransactionCollectionCommandHandler :
        ValidatableRequestHandler<CreateTransactionCollectionCommand>,
        IRequestHandler<CreateTransactionCollectionCommand, IEnumerable<TransactionForReturnDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;
        

        public CreateTransactionCollectionCommandHandler(
            IMapper mapper, 
            IAuthenticatedTransactionRepository authenticatedTransactionRepository)
        {
            _mapper = mapper;
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
        }

        public async Task<IEnumerable<TransactionForReturnDto>> Handle(
            CreateTransactionCollectionCommand request, 
            CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var transactionCollection = _mapper.Map<IEnumerable<Transaction>>(request.Transactions);

            transactionCollection = await _authenticatedTransactionRepository.AddRangeAsync(transactionCollection);

            return _mapper.Map<IEnumerable<TransactionForReturnDto>>(transactionCollection);
        }
    }
}