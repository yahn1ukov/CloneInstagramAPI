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
        private readonly ICommentRepository _commentRepository;

        public UpdatePostDeleteCommentByIdCommandHandler
        (
            IUserRepository userRepository,
            ICommentRepository commentRepository
        )
        {
            _userRepository = userRepository;
            _commentRepository = commentRepository;
        }
        public async Task<bool> Handle(UpdatePostDeleteCommentByIdCommand command, CancellationToken cancellationToken)
        {
            if(await _userRepository.Get() is not User user)
            {
                throw new UserNotFoundException();
            }

            if(await _commentRepository.GetById(command.CommentId) is not Comment comment)
            {
                throw new PostCommentNotFoundException();
            }

            if(comment.UserId != user.Id)
            {
                throw new PostCommentCannotBeDeletedException();
            }

            await _commentRepository.Remove(comment);

            return true;
        }
    }
}