using CloneInstagramAPI.Application.Posts.Common;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Queries
{
    public record GetAllPostsWithoutUsersQuery() : IRequest<IEnumerable<GetAllPostsResult>>;
}