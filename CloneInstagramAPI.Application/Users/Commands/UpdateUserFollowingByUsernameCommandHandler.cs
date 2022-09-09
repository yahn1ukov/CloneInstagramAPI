using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public class UpdateUserFollowingByUsernameCommandHandler : IRequestHandler<UpdateUserFollowingByUsernameCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IFollowerRepository _followerRepository;

        public UpdateUserFollowingByUsernameCommandHandler
        (
            IUserRepository userRepository,
            IFollowerRepository followerRepository
        )
        {
            _userRepository = userRepository;
            _followerRepository = followerRepository;
        }
        
        public async Task<bool> Handle(UpdateUserFollowingByUsernameCommand command, CancellationToken cancellationToken)
        {
            if(await _userRepository.Get() is not User user)
            {
                throw new UserNotFoundException();
            }

            if(await _userRepository.GetByUsername(command.Username) is not User userFollowing)
            {
                throw new UserNotFoundException();
            }

            if(await _followerRepository.GetById(user.Id, userFollowing.Id) is not null)
            {
                throw new UserFollowingAlreadyExistsException();
            }

            var following = new Follower
            {
                UserId = user.Id,
                FollowingUserId = userFollowing.Id
            };

            await _followerRepository.Add(following);

            return true;
        }
    }
}