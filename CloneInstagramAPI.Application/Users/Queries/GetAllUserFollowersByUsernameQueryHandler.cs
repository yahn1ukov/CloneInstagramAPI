using AutoMapper;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Application.Users.Common;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Users.Queries
{
    public class GetAllUserFollowersByUsernameQueryHandler : IRequestHandler<GetAllUserFollowersByUsernameQuery, ICollection<GetAllFollowersResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IFollowerRepository _followerRepository;
        private readonly IMapper _mapper;

        public GetAllUserFollowersByUsernameQueryHandler
        (
            IUserRepository userRepository,
            IFollowerRepository followerRepository,
            IMapper mapper
        )
        {
            _userRepository = userRepository;
            _followerRepository = followerRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<GetAllFollowersResult>> Handle(GetAllUserFollowersByUsernameQuery query, CancellationToken cancellationToken)
        {
            if(await _userRepository.GetByUsername(query.Username) is not User user)
            {
                throw new UserNotFoundException();
            }

            var followers = await _followerRepository.GetAllFollowers(user.Id);

            return followers
                .Select(f => new GetAllFollowersResult(f.Id, f.User.Username, f.User.FullName))
                .ToList();
        }
    }
}