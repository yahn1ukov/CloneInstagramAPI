using CloneInstagramAPI.Application.Common.Exception.Error.Post;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public class UpdatePostUnsetLikeCommandHandler : IRequestHandler<UpdatePostUnsetLikeCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly ILikeRepository _likeRepository;

        public UpdatePostUnsetLikeCommandHandler
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

        public async Task<bool> Handle(UpdatePostUnsetLikeCommand command, CancellationToken cancellationToken)
        {
            if(await _userRepository.GetById() is not User user)
            {
                throw new UserNotFoundException();
            }

            if(await _postRepository.GetById(command.PostId) is not Post post)
            {
                throw new PostNotFoundException();
            }

            Like like = await _likeRepository.Get(user.Id, post.Id);

            await _likeRepository.Unset(like);

            return true;
        }
    }
}