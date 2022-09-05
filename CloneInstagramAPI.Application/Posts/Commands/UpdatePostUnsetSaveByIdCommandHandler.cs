using CloneInstagramAPI.Application.Common.Exception.Error.Post;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public class UpdatePostUnsetSaveByIdCommandHandler : IRequestHandler<UpdatePostUnsetSaveByIdCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly IPostActionRepository<Save> _saveRepository;

        public UpdatePostUnsetSaveByIdCommandHandler
        (
            IUserRepository userRepository, 
            IPostRepository postRepository,
            IPostActionRepository<Save> saveRepository
        )
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
            _saveRepository = saveRepository;
        }

        public async Task<bool> Handle(UpdatePostUnsetSaveByIdCommand command, CancellationToken cancellationToken)
        {
            if(await _userRepository.GetById() is not User user)
            {
                throw new UserNotFoundException();
            }

            if(await _postRepository.GetById(command.PostId) is not Post post)
            {
                throw new PostNotFoundException();
            }

            var save = await _saveRepository.Get(user.Id, post.Id);

            await _saveRepository.Remove(save);

            return true;
        }
    }
}