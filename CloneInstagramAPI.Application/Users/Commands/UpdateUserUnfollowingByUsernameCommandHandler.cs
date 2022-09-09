using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public class UpdateUserUnfollowingByUsernameCommandHandler : IRequestHandler<UpdateUserUnfollowingByUsernameCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IFollowerRepository _followerRepository;

        public UpdateUserUnfollowingByUsernameCommandHandler
        (
            IUserRepository userRepository,
            IFollowerRepository followerRepository
        )
        {
            _userRepository = userRepository;
            _followerRepository = followerRepository;
        }

        public async Task<bool> Handle(UpdateUserUnfollowingByUsernameCommand command, CancellationToken cancellationToken)
        {
            if(await _userRepository.Get() is not User user)
            {
                throw new UserNotFoundException();
            }

            if(await _userRepository.GetByUsername(command.Username) is not User userFollowing)
            {
                throw new UserNotFoundException();
            }

            if(await _followerRepository.GetById(user.Id, userFollowing.Id) is not Follower following)
            {
                throw new UserFollowingNotFoundException();
            }

            await _followerRepository.Remove(following);

            return true;
        }
    }
}