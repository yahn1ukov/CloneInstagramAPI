using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public class UpdateUserUnbanByIdCommandHandler : IRequestHandler<UpdateUserUnbanByIdCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserUnbanByIdCommandHandler
        (
            IUserRepository userRepository
        )
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(UpdateUserUnbanByIdCommand command, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetById(command.UserId) is not User user)
            {
                throw new UserNotFoundException();
            }

            if (!user.IsBanned)
            {
                throw new UserIsUnbannedException();
            }

            user.IsBanned = false;

            await _userRepository.Update(user);

            return true;
        }
    }
}