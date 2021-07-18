using AutoMapper;
using TradeTracker.Api.DTOs.Identity.Authentication;
using TradeTracker.Api.DTOs.Identity.Registration;
using TradeTracker.Identity.Models.Authentication;
using TradeTracker.Identity.Models.Registration;

namespace TradeTracker.Api.Profiles
{
    public class IdentityProfile : Profile
    {
        public IdentityProfile()
        {
            CreateMap<AuthenticationRequestDto, AuthenticationRequest>();

            CreateMap<AuthenticationResponse, AuthenticationResponseDto>();

            CreateMap<RegistrationRequestDto, RegistrationRequest>();

            CreateMap<RegistrationResponse, RegistrationResponseDto>();
        }
    }
}
