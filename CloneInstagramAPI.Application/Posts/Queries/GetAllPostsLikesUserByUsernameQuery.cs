using CloneInstagramAPI.Application.Posts.Common;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Queries
{
    public record GetAllPostsLikesUserByUsernameQuery
    (
        string Username
    ) : IRequest<IEnumerable<GetAllPostsResult>>;
}