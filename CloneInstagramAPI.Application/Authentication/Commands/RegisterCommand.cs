using CloneInstagramAPI.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace CloneInstagramAPI.Application.Authentication.Commands
{
    public record RegisterCommand
    (
        string Email,
        string FullName,
        string UserName,
        string Password
    ) : IRequest<ErrorOr<AuthenticationResult>>;
}