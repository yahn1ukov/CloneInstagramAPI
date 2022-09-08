using AutoMapper;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Application.Posts.Common;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Queries
{
    public class GetAllPostsSavesUserByUsernameQueryHandler : IRequestHandler<GetAllPostsSavesUserByUsernameQuery, ICollection<GetAllPostsResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetAllPostsSavesUserByUsernameQueryHandler
        (
            IUserRepository userRepository,
            IPostRepository postRepository,
            IMapper mapper
        )
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<GetAllPostsResult>> Handle(GetAllPostsSavesUserByUsernameQuery query, CancellationToken cancellationToken)
        {
            if(await _userRepository.GetByUsername(query.Username) is not User user)
            {
                throw new UserNotFoundException();
            }

            var posts = await _postRepository.GetAllSavesUserById(user.Id);

            return posts
                .Select(p => _mapper.Map<GetAllPostsResult>(p))
                .ToList();
        }
    }
}