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
using TradeTracker.Application.Models.Pagination;
using TradeTracker.Application.Requests;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Positions.Queries.GetPositions
{
    public class GetPositionsQueryHandler : 
        ValidatableRequestHandler<GetPositionsQuery>,
        IRequestHandler<GetPositionsQuery, PagedPositionsBaseDto>
    {
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IMapper _mapper;
        private readonly IPositionRepository _positionRepository;
        private readonly IPositionService _positionService;

        public GetPositionsQueryHandler(
            ILoggedInUserService loggedInUserService,
            IMapper mapper, 
            IPositionRepository positionRepository,
            IPositionService positionService)
        {
            _loggedInUserService = loggedInUserService;
            _mapper = mapper;
            _positionRepository = positionRepository;
            _positionService = positionService;
        }

        public async Task<PagedPositionsBaseDto> Handle(GetPositionsQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var userAccessKey = _loggedInUserService.AccessKey;

            var parameters = _mapper.Map<PagedPositionsResourceParameters>(request);

            var pagedPositions = await _positionRepository.GetPagedPositionsAsync(userAccessKey, parameters);
            
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
