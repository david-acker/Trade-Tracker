using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Exceptions;
using TradeTracker.Application.Interfaces.Persistence;
using TradeTracker.Application.Models.Pagination;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Positions.Queries.GetPositions
{
    public class GetPositionsQueryHandler : IRequestHandler<GetPositionsQuery, PagedPositionsDto>
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;

        public GetPositionsQueryHandler(IMapper mapper, IPositionRepository positionRepository)
        {
            _mapper = mapper;
            _positionRepository = positionRepository;
        }

        public async Task<PagedPositionsDto> Handle(GetPositionsQuery request, CancellationToken cancellationToken)
        {
            await ValidateRequest(request);

            var parameters = _mapper.Map<PagedPositionsResourceParameters>(request);

            var pagedPositions = await _positionRepository.GetPagedPositionsAsync(parameters);
            
            var positionsForReturn = _mapper.Map<PagedList<Position>, List<PositionForReturnDto>>(pagedPositions);

            return new PagedPositionsDto()
            {
                CurrentPage = pagedPositions.CurrentPage,
                TotalPages = pagedPositions.TotalPages,
                PageSize = pagedPositions.PageSize,
                TotalCount = pagedPositions.TotalCount,
                HasPrevious = pagedPositions.HasPrevious,
                HasNext = pagedPositions.HasNext,
                Items = positionsForReturn
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
    }
}
