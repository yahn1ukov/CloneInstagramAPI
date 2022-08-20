using CloneInstagramAPI.Application.Users.Common;
using MediatR;

namespace CloneInstagramAPI.Application.Users.Queries
{
    public record GetUserByUserNameQuery(string UserName) : IRequest<ProfileResult>;
}