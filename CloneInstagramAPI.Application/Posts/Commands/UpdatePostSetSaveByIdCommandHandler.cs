using CloneInstagramAPI.Application.Common.Exception.Error.Post;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public class UpdatePostSetSaveByIdCommandHandler : IRequestHandler<UpdatePostSetSaveByIdCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly ISaveRepository _saveRepository;

        public UpdatePostSetSaveByIdCommandHandler
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

        public async Task<bool> Handle(UpdatePostSetSaveByIdCommand command, CancellationToken cancellationToken)
        {
            if(await _userRepository.Get() is not User user)
            {
                throw new UserNotFoundException();
            }

            if(await _postRepository.GetById(command.PostId) is not Post post)
            {
                throw new PostNotFoundException();
            }

            if(await _saveRepository.GetById(user.Id, post.Id) is not null)
            {
                throw new PostSaveAlreadyExistsException();
            }

            var save = new Save
            {
                UserId = user.Id,
                PostId = post.Id
            };

            await _saveRepository.Add(save);

            return true;
        }
    }
}