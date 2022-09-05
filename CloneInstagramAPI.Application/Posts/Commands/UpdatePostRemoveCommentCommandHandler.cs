using CloneInstagramAPI.Application.Common.Exception.Error.Post;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public class UpdatePostRemoveCommentCommandHandler : IRequestHandler<UpdatePostRemoveCommentCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly IPostActionRepository<Comment> _commentRepository;

        public UpdatePostRemoveCommentCommandHandler
        (
            IUserRepository userRepository,
            IPostRepository postRepository,
            IPostActionRepository<Comment> commentRepository
        )
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
            _commentRepository = commentRepository;
        }
        public async Task<bool> Handle(UpdatePostRemoveCommentCommand command, CancellationToken cancellationToken)
        {
            if(await _userRepository.GetById() is not User user)
            {
                throw new UserNotFoundException();
            }

            if(await  _postRepository.GetById(command.PostId) is not Post post)
            {
                throw new PostNotFoundException();
            }

            Comment comment = await _commentRepository.Get(user.Id, post.Id);

            await _commentRepository.Remove(comment);

            return true;
        }
    }
}