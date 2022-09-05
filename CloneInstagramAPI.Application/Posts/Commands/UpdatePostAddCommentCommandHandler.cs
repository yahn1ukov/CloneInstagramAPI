using CloneInstagramAPI.Application.Common.Exception.Error.Post;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public class UpdatePostAddCommentCommandHandler : IRequestHandler<UpdatePostAddCommentCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly IPostActionRepository<Comment> _commentRepository;

        public UpdatePostAddCommentCommandHandler
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

        public async Task<bool> Handle(UpdatePostAddCommentCommand command, CancellationToken cancellationToken)
        {
            if(await _userRepository.GetById() is not User user)
            {
                throw new UserNotFoundException();
            }

            if(await  _postRepository.GetById(command.PostId) is not Post post)
            {
                throw new PostNotFoundException();
            }

            Comment comment = new Comment
            {
                Message = command.Message,
                UserId = user.Id,
                PostId = post.Id
            };

            await _commentRepository.Add(comment);

            return true;
        }
    }
}