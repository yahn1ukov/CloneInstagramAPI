using CloneInstagramAPI.Application.Common.Exception.Error.Post;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public class UpdatePostDescriptionCommandHandler : IRequestHandler<UpdatePostDescriptionCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;

        public UpdatePostDescriptionCommandHandler(IUserRepository userRepository, IPostRepository postRepository)
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
        }

        public async Task<bool> Handle(UpdatePostDescriptionCommand command, CancellationToken cancellationToken)
        {
            if(await _userRepository.GetById() is not User user)
            {
                throw new UserNotFoundException();
            }

            if(await _postRepository.GetById(command.PostId) is not Post post)
            {
                throw new PostNotFoundException();
            }

            if(user.Id != post.UserId)
            {
                throw new PostCannotBeChangedException();
            }

            post.Description = command.Description;

            await _postRepository.Update(post);

            return true;
        }
    }
}