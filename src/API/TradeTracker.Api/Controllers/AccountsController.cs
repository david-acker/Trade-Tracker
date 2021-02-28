using TradeTracker.Application.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TradeTracker.Application.Interfaces.Identity;

namespace TradeTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AccountsController(IAuthenticationService authenticationService)
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
        public IActionResult GetAccountOptions()
        {
            Response.Headers.Add("Allow", "OPTIONS,POST");
            
            return NoContent();
        }
    }
}
