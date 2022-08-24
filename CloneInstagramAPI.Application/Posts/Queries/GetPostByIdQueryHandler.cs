using CloneInstagramAPI.Application.Common.Exception.Error.Post;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Application.Posts.Common;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Queries
{
    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, PostResult>
    {
        private readonly IPostRepository _postRepository;

        public GetPostByIdQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<PostResult> Handle(GetPostByIdQuery query, CancellationToken cancellationToken)
        {
            if (await _postRepository.GetById(query.Id) is not Post post)
            {
                throw new PostNotFoundException();
            }

            return new PostResult
            (
                post.Id,
                post.Content,
                post.Description,
                post.User.Avatar,
                post.User.Username,
                post.CreatedAt
            );
        }
    }
}