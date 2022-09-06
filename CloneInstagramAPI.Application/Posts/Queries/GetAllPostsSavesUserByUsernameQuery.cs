using CloneInstagramAPI.Application.Posts.Common;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Queries
{
    public record GetAllPostsSavesUserByUsernameQuery
    (
        string Username
    ) : IRequest<IEnumerable<GetAllPostsResult>>;
}