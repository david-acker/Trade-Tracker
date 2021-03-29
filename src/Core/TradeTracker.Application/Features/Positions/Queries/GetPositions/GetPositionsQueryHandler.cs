using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Interfaces.Infrastructure;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Models.Pagination;
using TradeTracker.Application.Requests.ValidatedRequestHandler;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Positions.Queries.GetPositions
{
    public class GetPositionsQueryHandler : 
        ValidatableRequestHandler<GetPositionsQuery, GetPositionsQueryValidator>,
        IRequestHandler<GetPositionsQuery, PagedPositionsBaseDto>
    {
        private readonly IMapper _mapper;
        private readonly IPositionRepository _positionRepository;
        private readonly IPositionService _positionService;

        public GetPositionsQueryHandler(
            IMapper mapper, 
            IPositionRepository positionRepository,
            IPositionService positionService)
        {
            _mapper = mapper;
            _positionRepository = positionRepository;
            _positionService = positionService;
        }

        public async Task<PagedPositionsBaseDto> Handle(GetPositionsQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var parameters = _mapper.Map<PagedPositionsResourceParameters>(request);

            var pagedPositions = await _positionRepository.GetPagedPositionsAsync(parameters);
            
            var positionsForReturn = _mapper.Map<PagedList<Position>, List<PositionForReturnDto>>(pagedPositions);

            var positionsForReturnWithSourceInformation = 
                await AddSourceInformation(positionsForReturn, request.AccessKey);

            return new PagedPositionsBaseDto()
            {
                CurrentPage = pagedPositions.CurrentPage,
                TotalPages = pagedPositions.TotalPages,
                PageSize = pagedPositions.PageSize,
                TotalCount = pagedPositions.TotalCount,
                HasPrevious = pagedPositions.HasPrevious,
                HasNext = pagedPositions.HasNext,
                Items = positionsForReturnWithSourceInformation
            };
        }
        
        private async Task<IEnumerable<PositionForReturnDto>> AddSourceInformation(
            IEnumerable<PositionForReturnDto> positions, 
            Guid accessKey)
        {
            var tasks = positions.Select(async (position) =>
            {
                position.AverageCostBasis = await _positionService
                    .CalculateAverageCostBasis(
                        accessKey,
                        position.Symbol);

                position.SourceTransactionMap = await _positionService
                    .CreateSourceTransactionMap(
                        accessKey,
                        position.Symbol);
                
                return position;
            });

            var positionsWithSourceInformation = await Task.WhenAll(tasks);

            return positionsWithSourceInformation;
        }
    }
}
