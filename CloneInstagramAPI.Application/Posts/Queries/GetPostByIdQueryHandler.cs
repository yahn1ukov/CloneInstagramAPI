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
        private readonly IActionRepository<Like> _likeRepository;
        private readonly IActionRepository<Save> _saveRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GetPostByIdQueryHandler
        (
            IUserRepository userRepository,
            IPostRepository postRepository,
            IActionRepository<Like> likeRepository,
            IActionRepository<Save> saveRepository, 
            ICommentRepository commentRepository,
            IMapper mapper
        )
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
            _likeRepository = likeRepository;
            _saveRepository = saveRepository;
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
            
            var likes = await _likeRepository.GetAll(post.Id);
            var saves = await _saveRepository.GetAll(post.Id);
            var comments = await _commentRepository.GetAll(post.Id);

            var isLike = likes.Any(l => l.UserId == user.Id) ? true : false;
            var countLikes = likes.Count > 0 ? likes.Count : 0;

            var isSave = saves.Any(s => s.UserId == user.Id) ? true : false;
            var countSaves = saves.Count > 0 ? saves.Count : 0;


            var commentsMapping = comments
                        .Select(c => new GetAllCommentsResult(c.Id, c.Message, c.User.Username, c.User.Avatar, c.CreatedAt))
                        .ToList();
            int countComments = comments.Count > 0 ? comments.Count : 0;

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