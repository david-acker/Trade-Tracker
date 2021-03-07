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

namespace TradeTracker.Application.Features.Transactions.Queries.GetTransactions
{
    public class GetTransactionsQueryHandler : IRequestHandler<GetTransactionsQuery, PagedTransactionsDto>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;
        
        public GetTransactionsQueryHandler(
            IMapper mapper, 
            ITransactionRepository transactionRepository)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        }

        public async Task<PagedTransactionsDto> Handle(GetTransactionsQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var parameters = _mapper.Map<GetPagedTransactionsResourceParameters>(request);

            var pagedList = await _transactionRepository.GetPagedTransactionsList(parameters);
            
            var transactionsToReturn = _mapper.Map<PagedList<Transaction>, List<TransactionForReturnDto>>(pagedList);

            return new PagedTransactionsDto()
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

        public async Task ValidateRequest(GetTransactionsQuery request)
        {
            var validator = new GetTransactionsQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }  
        }
    }
}
