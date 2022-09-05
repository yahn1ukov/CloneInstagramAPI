using AutoMapper;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Application.Posts.Common;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Queries
{
    public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, IEnumerable<GetAllPostsResult>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetAllPostsQueryHandler
        (
            IPostRepository postRepository,
            IMapper mapper
        )
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllPostsResult>> Handle(GetAllPostsQuery query, CancellationToken cancellationToken)
        {
            var posts = await _postRepository.GetAll();

            return posts
                .Select(p => _mapper.Map<GetAllPostsResult>(p))
                .ToList();
        }
    }
}