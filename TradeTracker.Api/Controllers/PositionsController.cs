using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TradeTracker.Business.Services;
using TradeTracker.Core.DomainModels;

namespace TradeTracker.Api.Controllers
{
    [Route("api/positions")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IPositionsService _positionsService;
        private readonly IMapper _mapper;

        public PositionsController(
            IPositionsService positionsService,
            IMapper mapper)
        {
            _positionsService = positionsService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{symbol}")]
        public async Task<IActionResult> GetAsync(string symbol)
        {
            var accessKey = Guid.Empty.ToString();

            var position = await _positionsService.GetPosition(symbol, accessKey);
            if (position == null)
            {
                return NotFound(symbol);
            }

            var positionDomainModel = _mapper.Map<PositionDomainModel>(position);

            return Ok(positionDomainModel);
        }
    }
}
