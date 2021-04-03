using System.Threading.Tasks;
using TradeTracker.Application.Models.Common.Authentication;

namespace TradeTracker.Application.Common.Interfaces.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}
