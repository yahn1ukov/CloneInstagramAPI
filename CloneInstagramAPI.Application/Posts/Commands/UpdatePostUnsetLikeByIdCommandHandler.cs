using CloneInstagramAPI.Application.Common.Exception.Error.Post;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public class UpdatePostUnsetLikeByIdCommandHandler : IRequestHandler<UpdatePostUnsetLikeByIdCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly IPostActionRepository<Like> _likeRepository;

        public UpdatePostUnsetLikeByIdCommandHandler
        (
            IUserRepository userRepository, 
            IPostRepository postRepository,
            IPostActionRepository<Like> likeRepository
        )
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
            _likeRepository = likeRepository;
        }

        public async Task<bool> Handle(UpdatePostUnsetLikeByIdCommand command, CancellationToken cancellationToken)
        {
            if(await _userRepository.GetById() is not User user)
            {
                throw new UserNotFoundException();
            }

            if(await _postRepository.GetById(command.PostId) is not Post post)
            {
                throw new PostNotFoundException();
            }

            if(await _likeRepository.Get(user.Id, post.Id) is not Like like)
            {
                throw new PostLikeNotFoundException();
            }

            await _likeRepository.Remove(like);

            return true;
        }
    }
}