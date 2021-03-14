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
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Positions.Queries.GetPositions
{
    public class GetPositionsQueryHandler : IRequestHandler<GetPositionsQuery, PagedPositionsDto>
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

        public async Task<PagedPositionsDto> Handle(GetPositionsQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var parameters = _mapper.Map<PagedPositionsResourceParameters>(request);

            var pagedPositions = await _positionRepository.GetPagedPositionsAsync(parameters);
            
            var positionsForReturn = _mapper.Map<PagedList<Position>, List<PositionForReturnDto>>(pagedPositions);

            var positionsForReturnWithAverageCostBasis = 
                await AddAverageCostBasis(positionsForReturn, request.AccessKey);

            return new PagedPositionsDto()
            {
                CurrentPage = pagedPositions.CurrentPage,
                TotalPages = pagedPositions.TotalPages,
                PageSize = pagedPositions.PageSize,
                TotalCount = pagedPositions.TotalCount,
                HasPrevious = pagedPositions.HasPrevious,
                HasNext = pagedPositions.HasNext,
                Items = positionsForReturnWithAverageCostBasis
            };
        }

        private async Task ValidateRequest(GetPositionsQuery request)
        {
            var validator = new GetPositionsQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }  
        }

        private async Task<IEnumerable<PositionForReturnDto>> AddAverageCostBasis(
            IEnumerable<PositionForReturnDto> positions, 
            Guid accessKey)
        {
            var tasks = positions.Select(async (position) =>
            {
                position.AverageCostBasis = await _positionService
                    .CalculateAverageCostBasis(
                        accessKey,
                        position.Symbol);
                
                return position;
            });

            var positionsWithAverageCostBasis = await Task.WhenAll(tasks);

            return positionsWithAverageCostBasis;
        }
    }
}
