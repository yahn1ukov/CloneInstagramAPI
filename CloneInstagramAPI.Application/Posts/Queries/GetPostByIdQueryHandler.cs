using AutoMapper;
using CloneInstagramAPI.Application.Common.Exception.Error.Post;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Application.Posts.Common;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Queries
{
    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, GetPostResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GetPostByIdQueryHandler
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

        public async Task<GetPostResult> Handle(GetPostByIdQuery query, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetById() is not User user)
            {
                throw new UserNotFoundException();
            }

            if (await _postRepository.GetById(query.PostId) is not Post post)
            {
                throw new PostNotFoundException();
            }

            if (post.UserId is null)
            {
                throw new PostNotFoundException();
            }

            var comments = await _commentRepository.GetAll(post.Id);

            var isLike = post.Likes.Any(l => l.UserId == user.Id) ? true : false;
            var countLikes = post.Likes.Count > 0 ? post.Likes.Count : 0;

            var isSave = post.Saves.Any(s => s.UserId == user.Id) ? true : false;
            var countSaves = post.Saves.Count > 0 ? post.Saves.Count : 0;

            var commentsMapping = comments
                        .Select(c => new GetAllCommentsResult(c.Id, c.Message, c.User.Username, c.User.Avatar, c.CreatedAt))
                        .ToList();
            int countComments = post.Comments.Count > 0 ? post.Comments.Count : 0;

            return new GetPostResult
            (
                post.Id, post.Content, post.Description,
                post.User.Avatar, post.User.Username,
                countLikes, countSaves, countComments,
                commentsMapping, isLike, isSave, post.CreatedAt
            );
        }
    }
}