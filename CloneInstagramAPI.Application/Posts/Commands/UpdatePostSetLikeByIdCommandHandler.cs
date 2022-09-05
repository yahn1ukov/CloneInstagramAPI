using System.Reflection.Metadata;
using CloneInstagramAPI.Application.Common.Exception.Error.Post;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public class UpdatePostSetLikeByIdCommandHandler : IRequestHandler<UpdatePostSetLikeByIdCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly IPostActionRepository<Like> _likeRepository;

        public UpdatePostSetLikeByIdCommandHandler
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

        public async Task<bool> Handle(UpdatePostSetLikeByIdCommand command, CancellationToken cancellationToken)
        {
            if(await _userRepository.GetById() is not User user)
            {
                throw new UserNotFoundException();
            }

            if(await _postRepository.GetById(command.PostId) is not Post post)
            {
                throw new PostNotFoundException();
            }

            var like = new Like
            {
                UserId = user.Id,
                PostId = post.Id
            };

            await _likeRepository.Add(like);

            return true;
        }
    }
}