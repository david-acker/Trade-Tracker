using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Interfaces;
using TradeTracker.Application.Interfaces.Infrastructure;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Interfaces.Persistence.Positions;
using TradeTracker.Application.Models.Pagination;
using TradeTracker.Application.Requests;
using TradeTracker.Application.ResourceParameters;
using TradeTracker.Application.ResourceParameters.Paged;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Positions.Queries.GetPositions
{
    public class GetPositionsQueryHandler : 
        ValidatableRequestHandler<GetPositionsQuery>,
        IRequestHandler<GetPositionsQuery, PagedPositionsBaseDto>
    {
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IMapper _mapper;
        private readonly IAuthenticatedPositionRepository _authenticatedPositionRepository;
        private readonly IPositionService _positionService;

        public GetPositionsQueryHandler(
            ILoggedInUserService loggedInUserService,
            IMapper mapper,
            IAuthenticatedPositionRepository authenticatedPositionRepository,
            IPositionService positionService)
        {
            _loggedInUserService = loggedInUserService;
            _mapper = mapper;
            _authenticatedPositionRepository = authenticatedPositionRepository;
            _positionService = positionService;
        }

        public async Task<PagedPositionsBaseDto> Handle(GetPositionsQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var parameters = _mapper.Map<PagedPositionsResourceParameters>(request);

            var pagedPositions = await _authenticatedPositionRepository.GetPagedResponseAsync(parameters);
            
            var positionsForReturn = _mapper.Map<PagedList<Position>, List<PositionForReturnDto>>(pagedPositions);

            var positionsForReturnWithSourceInformation = 
                await AddSourceInformation(positionsForReturn);

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
            IEnumerable<PositionForReturnDto> positions)
        {
            var tasks = positions.Select(async (position) =>
            {
                position.AverageCostBasis = await _positionService
                    .CalculateAverageCostBasis(
                        position.Symbol);

                position.SourceTransactionMap = await _positionService
                    .CreateSourceTransactionMap(
                        position.Symbol);
                
                return position;
            });

            var positionsWithSourceInformation = await Task.WhenAll(tasks);

            return positionsWithSourceInformation;
        }
    }
}
