using AutoMapper;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public CreatePostCommandHandler
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

        public async Task<bool> Handle(CreatePostCommand command, CancellationToken cancellationToken)
        {
            if(await _userRepository.Get() is not User user)
            {
                throw new UserNotFoundException();
            }

            var createdPost = _mapper.Map<Post>(command);

            createdPost.UserId = user.Id;

            await _postRepository.Create(createdPost);

            return true;
        }
    }
}