using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Application.Posts.Common;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Queries
{
    public class GetAllPostsFollowingsByUsernameQueryHandler : IRequestHandler<GetAllPostsFollowingsByUsernameQuery, ICollection<GetAllPostsFollowingsResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly IFollowerRepository _followerRepository;

        public GetAllPostsFollowingsByUsernameQueryHandler
        (
            IUserRepository userRepository,
            IPostRepository postRepository,
            IFollowerRepository followerRepository
        )
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
            _followerRepository = followerRepository;
        }

        public async Task<ICollection<GetAllPostsFollowingsResult>> Handle(GetAllPostsFollowingsByUsernameQuery query, CancellationToken cancellationToken)
        {
            if(await _userRepository.GetByUsername(query.Username) is not User user)
            {
                throw new UserNotFoundException();
            }

            var posts = await _postRepository.GetAll();
            var following = await _followerRepository.GetAllFollowingsById(user.Id);

            var postsFollowing = posts.Where(p => following.Any(f => p.UserId == f.FollowingUserId) || p.UserId == user.Id);

            return postsFollowing
                .Select(p => new GetAllPostsFollowingsResult
                    (
                        p.Id, p.Content, p.Description,
                        p.User.Avatar, p.User.Username,
                        p.Likes.Count > 0 ? p.Likes.Count : 0,
                        p.Saves.Count > 0 ? p.Saves.Count : 0,
                        p.Comments.Count > 0 ? p.Comments.Count : 0,
                        p.Likes.Any(l => l.UserId == user.Id) ? true : false,
                        p.Saves.Any(s => s.UserId == user.Id) ? true : false,
                        p.CreatedAt
                    )
                )
                .ToList();   
        }
    }
}