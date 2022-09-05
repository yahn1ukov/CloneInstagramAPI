using CloneInstagramAPI.Application.Posts.Common;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Queries
{
    public record GetAllPostsWithoutUserQuery() : IRequest<IEnumerable<AllPostsResult>>;
}