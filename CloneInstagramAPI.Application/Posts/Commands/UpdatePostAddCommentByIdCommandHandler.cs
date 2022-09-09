using AutoMapper;
using CloneInstagramAPI.Application.Common.Exception.Error.Post;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public class UpdatePostAddCommentByIdCommandHandler : IRequestHandler<UpdatePostAddCommentByIdCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public UpdatePostAddCommentByIdCommandHandler
        (
            IUserRepository userRepository,
            IPostRepository postRepository,
            ICommentRepository commentRepository,
            IMapper mapper
        )
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdatePostAddCommentByIdCommand command, CancellationToken cancellationToken)
        {
            if(await _userRepository.Get() is not User user)
            {
                throw new UserNotFoundException();
            }

            if(await  _postRepository.GetById(command.PostId) is not Post post)
            {
                throw new PostNotFoundException();
            }

            var comment = _mapper.Map<Comment>(command);

            comment.UserId = user.Id;
            comment.PostId = post.Id;

            await _commentRepository.Add(comment);

            return true;
        }
    }
}