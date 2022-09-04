using CloneInstagramAPI.Application.Common.Exception.Error.Post;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public class UpdatePostSetSaveCommandHandler : IRequestHandler<UpdatePostSetSaveCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly ISaveRepository _saveRepository;

        public UpdatePostSetSaveCommandHandler
        (
            IUserRepository userRepository, 
            IPostRepository postRepository,
            ISaveRepository saveRepository
        )
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
            _saveRepository = saveRepository;
        }

        public async Task<bool> Handle(UpdatePostSetSaveCommand command, CancellationToken cancellationToken)
        {
            if(await _userRepository.GetById() is not User user)
            {
                throw new UserNotFoundException();
            }

            if(await _postRepository.GetById(command.PostId) is not Post post)
            {
                throw new PostNotFoundException();
            }

            Save save = new Save
            {
                UserId = user.Id,
                PostId = post.Id
            };

            await _saveRepository.Set(save);

            return true;
        }
    }
}