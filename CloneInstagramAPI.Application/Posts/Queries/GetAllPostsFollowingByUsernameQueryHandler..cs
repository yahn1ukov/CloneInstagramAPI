using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Application.Posts.Common;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Queries
{
    public class GetAllPostsFollowingByUsernameQueryHandler : IRequestHandler<GetAllPostsFollowingByUsernameQuery, ICollection<GetAllPostsFollowingResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly IActionRepository<Like> _likeRepository;
        private readonly IActionRepository<Save> _saveRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IFollowerRepository _followerRepository;

        public GetAllPostsFollowingByUsernameQueryHandler
        (
            IUserRepository userRepository,
            IPostRepository postRepository,
            IActionRepository<Like> likeRepository,
            IActionRepository<Save> saveRepository,
            ICommentRepository commentRepository,
            IFollowerRepository followerRepository
        )
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
            _likeRepository = likeRepository;
            _saveRepository = saveRepository;
            _commentRepository = commentRepository;
            _followerRepository = followerRepository;
        }

        public async Task<ICollection<GetAllPostsFollowingResult>> Handle(GetAllPostsFollowingByUsernameQuery query, CancellationToken cancellationToken)
        {
            if(await _userRepository.GetByUsername(query.Username) is not User user)
            {
                throw new UserNotFoundException();
            }

            var posts = await _postRepository.GetAll();
            var following = await _followerRepository.GetAllFollowing(user.Id);
            var likes = await _likeRepository.GetAll();
            var saves = await _saveRepository.GetAll();
            var comments = await _commentRepository.GetAll();

            var postsFollowing = posts.Where(p => following.Any(f => p.UserId == f.FollowingUserId) && p.UserId == user.Id);

            return postsFollowing
                .Select(p => new GetAllPostsFollowingResult
                    (
                        p.Id, p.Content, p.Description,
                        p.User.Avatar, p.User.Username,
                        likes.Where(l => l.PostId == p.Id).ToList().Count > 0 ? likes.Where(l => l.PostId == p.Id).ToList().Count : 0,
                        saves.Where(s => s.PostId == p.Id).ToList().Count > 0 ? saves.Where(s => s.PostId == p.Id).ToList().Count : 0,
                        comments.Where(c => c.PostId == p.Id).ToList().Count > 0 ? comments.Where(c => c.PostId == p.Id).ToList().Count : 0,
                        likes.Any(l => l.PostId == p.Id && l.UserId == user.Id) ? true : false,
                        saves.Any(s => s.PostId == p.Id && s.UserId == user.Id) ? true : false,
                        p.CreatedAt
                    )
                )
                .ToList();   
        }
    }
}