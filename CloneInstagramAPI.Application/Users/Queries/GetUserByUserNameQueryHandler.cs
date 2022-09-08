using AutoMapper;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Application.Users.Common;
using CloneInstagramAPI.Domain.Entities;
using CloneInstagramAPI.Domain.Enums;
using MediatR;

namespace CloneInstagramAPI.Application.Users.Queries
{
    public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsernameQuery, GetUserResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostRepository _postRepository;
        private readonly IFollowerRepository _followerRepository;
        private readonly IMapper _mapper;

        public GetUserByUsernameQueryHandler
        (
            IUserRepository userRepository,
            IPostRepository postRepository,
            IFollowerRepository followerRepository,
            IMapper mapper
        )
        {
            _userRepository = userRepository;
            _postRepository = postRepository;
            _followerRepository = followerRepository;
            _mapper = mapper;
        }

        public async Task<GetUserResult> Handle(GetUserByUsernameQuery query, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetByUsername(query.Username) is not User user)
            {
                throw new UserNotFoundException();
            }

            if(user.Role.Equals(UserRole.ADMIN))
            {
                throw new UserCannotGetException();
            }

            var posts = await _postRepository.GetAllUserById(user.Id);
            var followers = await _followerRepository.GetAllFollowers(user.Id);
            var following = await _followerRepository.GetAllFollowing(user.Id);

            var countPosts = posts.Count > 0 ? posts.Count : 0;
            var countFollowers = followers.Count > 0 ? followers.Count : 0;
            var countFollowing = following.Count > 0 ? following.Count : 0;

            var isFollowing = following.Any(f => f.FollowingUserId == user.Id) ? true : false;

            return new GetUserResult
            (
                user.Email, user.FullName, user.Username,
                user.Avatar, user.WebSite, user.PhoneNumber,
                user.Gender.ToString(), user.Biography,
                countPosts, countFollowers, countFollowing,
                isFollowing
            );
        }
    }
}