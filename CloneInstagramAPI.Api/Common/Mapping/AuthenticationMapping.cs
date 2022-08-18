using AutoMapper;
using CloneInstagramAPI.Application.Authentication.Commands;
using CloneInstagramAPI.Application.Authentication.Common;
using CloneInstagramAPI.Application.Authentication.Queries;
using CloneInstagramAPI.Contracts.Authentication;

namespace CloneInstagramAPI.Api.Common.Mapping
{
    public class AuthenticationMapping : Profile
    {
        public AuthenticationMapping()
        {
            CreateMap<RegistrationRequest, RegistrationCommand>();
            CreateMap<LoginRequest, LoginQuery>();
            CreateMap<AuthenticationResult, LoginResponse>();
        }
    }
}