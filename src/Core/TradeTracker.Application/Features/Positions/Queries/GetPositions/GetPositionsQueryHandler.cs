using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TradeTracker.Application.Common.Behaviors;
using TradeTracker.Application.Common.Interfaces.Infrastructure;
using TradeTracker.Application.Common.Interfaces.Persistence.Positions;
using TradeTracker.Application.Common.Models.Resources.Parameters.Positions;
using TradeTracker.Application.Common.Models.Resources.Responses;
using TradeTracker.Domain.Entities;

namespace TradeTracker.Application.Features.Positions.Queries.GetPositions
{
    public class GetPositionsQueryHandler : 
        ValidatableRequestBehavior<GetPositionsQuery>,
        IRequestHandler<GetPositionsQuery, PagedPositionsBaseDto>
    {
        
        private readonly IAuthenticatedPositionRepository _authenticatedPositionRepository;
        private readonly IMapper _mapper;
        private readonly IPositionService _positionService;

        public GetPositionsQueryHandler(
            IAuthenticatedPositionRepository authenticatedPositionRepository,
            IMapper mapper,
            IPositionService positionService)
        {
            _authenticatedPositionRepository = authenticatedPositionRepository;
            _mapper = mapper;
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
