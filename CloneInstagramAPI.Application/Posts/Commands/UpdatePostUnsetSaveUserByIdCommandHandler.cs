using CloneInstagramAPI.Application.Common.Exception.Error.Post;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public class UpdatePostUnsetSaveUserByIdCommandHandler : IRequestHandler<UpdatePostUnsetSaveUserByIdCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;

        public UpdatePostUnsetSaveUserByIdCommandHandler
        (
            IUserRepository userRepository,
            IPostRepository postRepository
        )
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
        }

        public async Task<bool> Handle(UpdatePostUnsetSaveUserByIdCommand command, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetById() is not User user)
            {
                throw new UserNotFoundException();
            }

            if (await _postRepository.GetById(command.PostId) is not Post post)
            {
                throw new PostNotFoundException();
            }

            post.Saves.Remove(user.Id);

            await _postRepository.Update(post);

            return true;
        }
    }
}