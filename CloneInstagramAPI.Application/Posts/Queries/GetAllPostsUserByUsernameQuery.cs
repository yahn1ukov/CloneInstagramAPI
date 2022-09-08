using CloneInstagramAPI.Application.Posts.Common;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Queries
{
    public record GetAllPostsUserByUsernameQuery
    (
        string Username
    ) : IRequest<ICollection<GetAllPostsResult>>;
}