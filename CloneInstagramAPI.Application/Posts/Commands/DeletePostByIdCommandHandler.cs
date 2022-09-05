using CloneInstagramAPI.Application.Common.Exception.Error.Post;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using CloneInstagramAPI.Domain.Enums;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public class DeletePostByIdCommandHandler : IRequestHandler<DeletePostByIdCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;

        public DeletePostByIdCommandHandler
        (
            IUserRepository userRepository, 
            IPostRepository postRepository
        )
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
        }

        public async Task<bool> Handle(DeletePostByIdCommand command, CancellationToken cancellationToken)
        {
            if(await _userRepository.GetById() is not User user)
            {
                throw new UserNotFoundException();
            }

            if (await _postRepository.GetById(command.PostId) is not Post post)
            {
                throw new PostNotFoundException();
            }

            await _postRepository.Delete(post);

            return true;
        }
    }
}