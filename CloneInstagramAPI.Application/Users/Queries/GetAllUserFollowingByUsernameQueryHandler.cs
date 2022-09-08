using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Application.Users.Common;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Users.Queries
{
    public class GetAllUserFollowingByUsernameQueryHandler : IRequestHandler<GetAllUserFollowingByUsernameQuery, ICollection<GetAllFollowersResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IFollowerRepository _followerRepository;

        public GetAllUserFollowingByUsernameQueryHandler
        (
            IUserRepository userRepository,
            IFollowerRepository followerRepository
        )
        {
            _userRepository = userRepository;
            _followerRepository = followerRepository;
        }

        public async Task<ICollection<GetAllFollowersResult>> Handle(GetAllUserFollowingByUsernameQuery query, CancellationToken cancellationToken)
        {
            if(await _userRepository.GetByUsername(query.Username) is not User user)
            {
                throw new UserNotFoundException();
            }

            var following = await _followerRepository.GetAllFollowing(user.Id);

            return following
                .Select(f => new GetAllFollowersResult(f.Id, f.User.Username, f.User.FullName))
                .ToList();
        }
    }
}