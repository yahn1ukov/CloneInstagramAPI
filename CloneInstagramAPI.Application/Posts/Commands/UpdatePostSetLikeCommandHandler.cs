using CloneInstagramAPI.Application.Common.Exception.Error.Post;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public class UpdatePostSetLikeCommandHandler : IRequestHandler<UpdatePostSetLikeCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly ILikeRepository _likeRepository;

        public UpdatePostSetLikeCommandHandler
        (
            IUserRepository userRepository, 
            IPostRepository postRepository,
            ILikeRepository likeRepository
        )
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
            _likeRepository = likeRepository;
        }

        public async Task<bool> Handle(UpdatePostSetLikeCommand command, CancellationToken cancellationToken)
        {
            if(await _userRepository.GetById() is not User user)
            {
                throw new UserNotFoundException();
            }

            if(await _postRepository.GetById(command.PostId) is not Post post)
            {
                throw new PostNotFoundException();
            }

            Like like = new Like
            {
                UserId = user.Id,
                PostId = post.Id
            };

            await _likeRepository.Set(like);

            return true;
        }
    }
}