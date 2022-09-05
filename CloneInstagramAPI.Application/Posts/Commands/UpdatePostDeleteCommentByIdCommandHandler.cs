using CloneInstagramAPI.Application.Common.Exception.Error.Post;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public class UpdatePostDeleteCommentByIdCommandHandler : IRequestHandler<UpdatePostDeleteCommentByIdCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly IPostActionRepository<Comment> _commentRepository;

        public UpdatePostDeleteCommentByIdCommandHandler
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
        public async Task<bool> Handle(UpdatePostDeleteCommentByIdCommand command, CancellationToken cancellationToken)
        {
            if(await _userRepository.GetById() is not User user)
            {
                throw new UserNotFoundException();
            }

            if(await  _postRepository.GetById(command.CommentId) is not Post post)
            {
                throw new PostNotFoundException();
            }

            var comment = await _commentRepository.Get(user.Id, post.Id);

            await _commentRepository.Remove(comment);

            return true;
        }
    }
}