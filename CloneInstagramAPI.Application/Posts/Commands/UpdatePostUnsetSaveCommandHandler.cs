using CloneInstagramAPI.Application.Common.Exception.Error.Post;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public class UpdatePostUnsetSaveCommandHandler : IRequestHandler<UpdatePostUnsetSaveCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly ISaveRepository _saveRepository;

        public UpdatePostUnsetSaveCommandHandler
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

        public async Task<bool> Handle(UpdatePostUnsetSaveCommand command, CancellationToken cancellationToken)
        {
            if(await _userRepository.GetById() is not User user)
            {
                throw new UserNotFoundException();
            }

            if(await _postRepository.GetById(command.PostId) is not Post post)
            {
                throw new PostNotFoundException();
            }

            Save save = await _saveRepository.Get(user.Id, post.Id);

            await _saveRepository.Unset(save);

            return true;
        }
    }
}