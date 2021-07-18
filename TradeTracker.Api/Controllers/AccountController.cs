using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using TradeTracker.Identity.Services;
using TradeTracker.Api.DTOs.Identity.Authentication;
using TradeTracker.Api.DTOs.Identity.Registration;
using AutoMapper;
using TradeTracker.Identity.Models.Authentication;
using TradeTracker.Identity.Models.Registration;

namespace TradeTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;

        public AccountController(
            IAuthenticationService authenticationService,
            ILogger<AccountController> logger,
            IMapper mapper)
        {
            _authenticationService = authenticationService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("authenticate")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<AuthenticationResponseDto>> Authenticate(AuthenticationRequestDto requestDto)
        {
            _logger.LogInformation($"{nameof(AccountController)}: {nameof(Authenticate)} was called.");

            var request = _mapper.Map<AuthenticationRequest>(requestDto);

            var response = await _authenticationService.AuthenticateAsync(request);

            return Ok(_mapper.Map<AuthenticationResponseDto>(response));
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult<RegistrationResponseDto>> Register(RegistrationRequestDto requestDto)
        {
            _logger.LogInformation($"{nameof(AccountController)}: {nameof(Register)} was called.");

            var request = _mapper.Map<RegistrationRequest>(requestDto);

            var response = await _authenticationService.RegisterAsync(request);

            return Ok(_mapper.Map<RegistrationResponseDto>(response));
        }

        [HttpOptions("authenticate")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult OptionsForAuthenticate()
        {
            _logger.LogInformation($"{nameof(AccountController)}: {nameof(OptionsForAuthenticate)} was called.");

            Response.Headers.Add("Allow", "OPTIONS,POST");

            return NoContent();
        }

        [HttpOptions("register")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult OptionsForRegister()
        {
            _logger.LogInformation($"{nameof(AccountController)}: {nameof(OptionsForRegister)} was called.");

            Response.Headers.Add("Allow", "OPTIONS,POST");
            
            return NoContent();
        }
    }
}
