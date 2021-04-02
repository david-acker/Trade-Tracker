using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactions;
using TradeTracker.Application.Interfaces;
using TradeTracker.Application.Interfaces.Infrastructure;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Interfaces.Persistence.Positions;
using TradeTracker.Application.Interfaces.Persistence.Transactions;
using TradeTracker.Application.Requests;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Positions.Queries.GetPosition
{
    public class GetDetailedPositionQueryHandler : 
        ValidatableRequestHandler<GetDetailedPositionQuery>,
        IRequestHandler<GetDetailedPositionQuery, DetailedPositionForReturnDto>
    {
        private readonly ILoggedInUserService _loggedInUserService;        
        private readonly IMapper _mapper;
        private readonly IAuthenticatedPositionRepository _authenticatedPositionRepository;
        private readonly IPositionService _positionService;
        private readonly IAuthenticatedTransactionRepository _authenticatedTransactionRepository;

        public GetDetailedPositionQueryHandler(
            ILoggedInUserService loggedInUserService,
            IMapper mapper,
            IAuthenticatedPositionRepository authenticatedPositionRepository,
            IPositionService positionService,
            IAuthenticatedTransactionRepository authenticatedTransactionRepository)
        {
            _loggedInUserService = loggedInUserService;
            _mapper = mapper;
            _authenticatedPositionRepository = authenticatedPositionRepository;
            _positionService = positionService;
            _authenticatedTransactionRepository = authenticatedTransactionRepository;
        }

        public async Task<DetailedPositionForReturnDto> Handle(GetDetailedPositionQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var position = await _authenticatedPositionRepository.GetBySymbolAsync(request.Symbol);

            if (position == null)
            {
                throw new NotFoundException(nameof(Position), request.Symbol);
            }
            
            var positionForReturn = _mapper.Map<DetailedPositionForReturnDto>(position);

            positionForReturn.AverageCostBasis = await _positionService
                .CalculateAverageCostBasis(
                    request.Symbol);

            var sourceTransactionMap = await _positionService
                .CreateSourceTransactionMap(
                    request.Symbol);

            var tasks = sourceTransactionMap
                .Select(async (sourceLink) => 
                    {
                        return await CreateFullLink(
                            sourceLink);
                    })
                .ToList();

            var fullSourceTransactionMap = await Task.WhenAll(tasks);

            positionForReturn.SourceTransactionMap = fullSourceTransactionMap;

            return positionForReturn;
        }

        private async Task<FullSourceTransactionLink> CreateFullLink(
            SourceTransactionLink sourceLink)
        {
            var transaction = await _authenticatedTransactionRepository
                .GetByIdAsync(sourceLink.TransactionId);

            var transactionWithLinks = 
                _mapper.Map<TransactionForReturnWithLinksDto>(transaction);

            return new FullSourceTransactionLink()
            {
                DateTime = sourceLink.DateTime,
                LinkedQuantity = sourceLink.LinkedQuantity,
                TradePrice = sourceLink.TradePrice,
                Transaction = transactionWithLinks
            };
        } 
    }
}
