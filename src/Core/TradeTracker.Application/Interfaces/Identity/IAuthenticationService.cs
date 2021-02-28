using TradeTracker.Application.Models.Authentication;
using System.Threading.Tasks;

namespace TradeTracker.Application.Interfaces.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}
