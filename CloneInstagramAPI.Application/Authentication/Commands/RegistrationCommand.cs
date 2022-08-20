using CloneInstagramAPI.Application.Authentication.Common;
using MediatR;

namespace CloneInstagramAPI.Application.Authentication.Commands
{
    public record RegistrationCommand
    (
        string Email,
        string FullName,
        string UserName,
        string Password
    ) : IRequest<AuthenticationResult>;
}