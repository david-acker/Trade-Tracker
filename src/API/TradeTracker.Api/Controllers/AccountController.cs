using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TradeTracker.Application.Models.Authentication;
using TradeTracker.Application.Interfaces.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace TradeTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(
            IAuthenticationService authenticationService,
            ILogger<AccountController> logger)
        {
            _authenticationService = authenticationService;
            _logger = logger;
        }

        /// <summary>
        /// Authenticate an existing account.
        /// </summary>
        /// <param name="authenticationRequest">Authentication request containing account information</param>
        /// <returns>An ActionResult of type AuthenticationResponse</returns>
        /// <remarks>
        /// Sample request: \
        /// POST /api/account/authenticate \
        /// { \
        ///     "email": "yourEmail@yourEmail.com", \
        ///     "password": "yourPassword!1" \
        /// } 
        /// </remarks>
        /// <response code="422">Validation Error</response>
        [HttpPost("authenticate", Name="Authenticate")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<AuthenticationResponse>> Authenticate(
            AuthenticationRequest authenticationRequest)
        {
            _logger.LogInformation($"AccountController: {nameof(Authenticate)} was called.");

            return Ok(await _authenticationService.AuthenticateAsync(authenticationRequest));
        }

        /// <summary>
        /// Options for /api/account/authenticate URI.
        /// </summary>
        /// <remarks>
        /// Sample request: \
        /// OPTIONS /api/account/authenticate 
        /// </remarks>
        [HttpOptions("authenticate", Name="OptionsForAuthenticate")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult OptionsForAuthenticate()
        {
            _logger.LogInformation($"AccountController: {nameof(OptionsForAuthenticate)} was called.");

            Response.Headers.Add("Allow", "OPTIONS,POST");

            return NoContent();
        }

        /// <summary>
        /// Register a new account.
        /// </summary>
        /// <param name="registrationRequest">Registration request containing account information</param>
        /// <returns>An ActionResult of type RegistrationResponse</returns>
        /// <remarks>
        /// Sample request: \
        /// POST /api/account/register \
        /// { \
        ///     "firstName": "yourFirstName", \
        ///     "lastName" : "yourLastName", \
        ///     "email": "yourEmail@yourEmail.com", \
        ///     "userName": "yourUserName", \
        ///     "password": "yourPassword!1" \
        /// } 
        /// </remarks>
        /// <response code="422">Validation Error</response>
        [HttpPost("register", Name="Register")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<RegistrationResponse>> Register(
            RegistrationRequest registrationRequest)
        {
            _logger.LogInformation($"AccountController: {nameof(Register)} was called.");

            return Ok(await _authenticationService.RegisterAsync(registrationRequest));
        }

        /// <summary>
        /// Options for /api/account/register URI.
        /// </summary>
        /// <remarks>
        /// Sample request: \
        /// OPTIONS /api/account/register 
        /// </remarks>
        [HttpOptions("register", Name="OptionsForRegister")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult OptionsForRegister()
        {
            _logger.LogInformation($"AccountController: {nameof(OptionsForRegister)} was called.");

            Response.Headers.Add("Allow", "OPTIONS,POST");
            
            return NoContent();
        }
    }
}
