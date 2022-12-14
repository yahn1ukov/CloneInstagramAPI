using CloneInstagramAPI.Application.Posts.Common;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Queries
{
    public record GetAllPostsFollowingsByUsernameQuery
    (
        string Username
    ) : IRequest<ICollection<GetAllPostsFollowingsResult>>;
}