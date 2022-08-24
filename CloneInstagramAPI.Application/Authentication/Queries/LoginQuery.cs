using CloneInstagramAPI.Application.Authentication.Common;
using MediatR;

namespace CloneInstagramAPI.Application.Authentication.Queries
{
    public record LoginQuery
    (
        string Username,
        string Password
    ) : IRequest<LoginResult>;
}