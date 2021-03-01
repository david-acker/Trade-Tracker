using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TradeTracker.Application.Models.Authentication;
using TradeTracker.Application.Interfaces.Identity;

namespace TradeTracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService 
                ?? throw new ArgumentNullException(nameof(authenticationService));
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request)
        {
            return Ok(await _authenticationService.AuthenticateAsync(request));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> RegisterAsync(RegistrationRequest request)
        {
            return Ok(await _authenticationService.RegisterAsync(request));
        }

        [HttpOptions]
        public IActionResult GetAccountAuthenticateOptions()
        {
            Response.Headers.Add("Allow", "OPTIONS,POST");

            return NoContent();
        }

        [HttpOptions]
        public IActionResult GetAccountRegisterOptions()
        {
            Response.Headers.Add("Allow", "OPTIONS,POST");
            
            return NoContent();
        }
    }
}
