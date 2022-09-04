using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Application.Posts.Common;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Queries
{
    public class GetAllPostsWithoutUserQueryHandler : IRequestHandler<GetAllPostsWithoutUserQuery, IEnumerable<AllPostsResult>>
    {
        private readonly IPostRepository _postRepository;

        public GetAllPostsWithoutUserQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<AllPostsResult>> Handle(GetAllPostsWithoutUserQuery query, CancellationToken cancellationToken)
        {
            var posts = await _postRepository.GetAllWithoutUser();

            return posts
                .Select(p => new AllPostsResult(p.Id, p.Content))
                .ToList();
        }
    }
}