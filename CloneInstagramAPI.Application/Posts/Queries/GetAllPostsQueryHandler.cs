using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Application.Posts.Common;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Queries
{
    public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, IEnumerable<AllPostsResult>>
    {
        private readonly IPostRepository _postRepository;

        public GetAllPostsQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<AllPostsResult>> Handle(GetAllPostsQuery query, CancellationToken cancellationToken)
        {
            var posts = await _postRepository.GetAll();

            return posts
                .Select(p => new AllPostsResult(p.Id, p.Content))
                .ToList();
        }
    }
}