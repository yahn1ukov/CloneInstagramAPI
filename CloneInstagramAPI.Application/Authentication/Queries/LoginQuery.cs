using CloneInstagramAPI.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace CloneInstagramAPI.Application.Authentication.Queries
{
    public record LoginQuery
    (
        string UserName,
        string Password
    ) : IRequest<ErrorOr<AuthenticationResult>>;
}