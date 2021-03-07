using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TradeTracker.Application.Models.Authentication;
using TradeTracker.Application.Interfaces.Identity;
using Microsoft.Extensions.Logging;

namespace TradeTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpPost("authenticate", Name="Authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> Authenticate(AuthenticationRequest request)
        {
            _logger.LogInformation($"AccountController: {nameof(Authenticate)} was called.");

            return Ok(await _authenticationService.AuthenticateAsync(request));
        }

        [HttpOptions("authenticate", Name="OptionsForAuthenticate")]
        public IActionResult OptionsForAuthenticate()
        {
            _logger.LogInformation($"AccountController: {nameof(OptionsForAuthenticate)} was called.");

            Response.Headers.Add("Allow", "OPTIONS,POST");

            return NoContent();
        }

        [HttpPost("register", Name="Register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            _logger.LogInformation($"AccountController: {nameof(Register)} was called.");

            return Ok(await _authenticationService.RegisterAsync(request));
        }

        [HttpOptions("register", Name="OptionsForRegister")]
        public IActionResult OptionsForRegister()
        {
            _logger.LogInformation($"AccountController: {nameof(OptionsForRegister)} was called.");

            Response.Headers.Add("Allow", "OPTIONS,POST");
            
            return NoContent();
        }
    }
}
