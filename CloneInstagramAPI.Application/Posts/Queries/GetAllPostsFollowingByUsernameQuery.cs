using CloneInstagramAPI.Application.Posts.Common;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Queries
{
    public record GetAllPostsFollowingByUsernameQuery
    (
        string Username
    ) : IRequest<ICollection<GetAllPostsFollowingResult>>;
}