using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Models.Pagination;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactionsList
{
    public class GetTransactionsListQueryHandler : IRequestHandler<GetTransactionsListQuery, PagedTransactionsListVm>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        
        public GetTransactionsListQueryHandler(
            IMapper mapper, 
            ITransactionRepository transactionRepository)
        {
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
            _transactionRepository = transactionRepository
                ?? throw new ArgumentNullException(nameof(transactionRepository));
        }

        public async Task<PagedTransactionsListVm> Handle(GetTransactionsListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetTransactionsListQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            var parameters = _mapper.Map<GetPagedTransactionsListResourceParameters>(request);

            var pagedList = await _transactionRepository.GetPagedTransactionsList(parameters);
            
            var transactionsToReturn = _mapper.Map<PagedList<Transaction>, List<TransactionForReturnDto>>(pagedList);

            return new PagedTransactionsListVm()
            {
                CurrentPage = pagedList.CurrentPage,
                TotalPages = pagedList.TotalPages,
                PageSize = pagedList.PageSize,
                TotalCount = pagedList.TotalCount,
                HasPrevious = pagedList.HasPrevious,
                HasNext = pagedList.HasNext,
                Items = transactionsToReturn
            };
        }
    }
}
