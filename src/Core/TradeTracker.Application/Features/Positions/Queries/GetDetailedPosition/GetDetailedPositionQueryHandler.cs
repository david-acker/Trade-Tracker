using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Features.Transactions.Queries.GetTransactions;
using TradeTracker.Application.Interfaces.Infrastructure;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Requests;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Positions.Queries.GetPosition
{
    public class GetDetailedPositionQueryHandler : 
        ValidatableRequestHandler<GetDetailedPositionQuery>,
        IRequestHandler<GetDetailedPositionQuery, DetailedPositionForReturnDto>
    {
        private readonly IMapper _mapper;
        private readonly IPositionRepository _positionRepository;
        private readonly IPositionService _positionService;
        private readonly ITransactionRepository _transactionRepository;

        public GetDetailedPositionQueryHandler(
            IMapper mapper, 
            IPositionRepository positionRepository,
            IPositionService positionService,
            ITransactionRepository transactionRepository)
        {
            _mapper = mapper;
            _positionRepository = positionRepository;
            _positionService = positionService;
            _transactionRepository = transactionRepository;
        }

        public async Task<DetailedPositionForReturnDto> Handle(GetDetailedPositionQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var position = await _positionRepository.GetBySymbolAsync(request.AccessKey, request.Symbol);

            if (position == null)
            {
                throw new NotFoundException(nameof(Position), request.Symbol);
            }
            
            var positionForReturn = _mapper.Map<DetailedPositionForReturnDto>(position);

            positionForReturn.AverageCostBasis = await _positionService
                .CalculateAverageCostBasis(
                    request.AccessKey, 
                    request.Symbol);

            var sourceTransactionMap = await _positionService
                .CreateSourceTransactionMap(
                    request.AccessKey,
                    request.Symbol);

            var tasks = sourceTransactionMap
                .Select(async (sourceLink) => 
                    {
                        return await CreateFullLink(
                            request.AccessKey, 
                            sourceLink);
                    })
                .ToList();

            var fullSourceTransactionMap = await Task.WhenAll(tasks);

            positionForReturn.SourceTransactionMap = fullSourceTransactionMap;

            return positionForReturn;
        }

        private async Task<FullSourceTransactionLink> CreateFullLink(
            Guid accessKey,
            SourceTransactionLink sourceLink)
        {
            var transaction = await _transactionRepository
                .GetByIdAsync(accessKey, sourceLink.TransactionId);

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
