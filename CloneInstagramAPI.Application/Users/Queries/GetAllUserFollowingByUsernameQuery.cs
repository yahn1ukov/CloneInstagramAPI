using CloneInstagramAPI.Application.Users.Common;
using MediatR;

namespace CloneInstagramAPI.Application.Users.Queries
{
    public record GetAllUserFollowingByUsernameQuery
    (
        string Username
    ) : IRequest<ICollection<GetAllFollowersResult>>;
}