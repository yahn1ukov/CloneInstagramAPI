using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using CloneInstagramAPI.Domain.Enums;
using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public class UpdateUserBanByIdCommandHandler : IRequestHandler<UpdateUserBanByIdCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserBanByIdCommandHandler
        (
            IUserRepository userRepository
        )
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(UpdateUserBanByIdCommand command, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetById(command.UserId) is not User user)
            {
                throw new UserNotFoundException();
            }

            if (user.IsBanned)
            {
                throw new UserIsBannedException();
            }

            if(user.Role.Equals(UserRole.ADMIN))
            {
                throw new UserAdminCannotBeBannedException();
            }

            user.IsBanned = true;

            await _userRepository.Update(user);

            return true;
        }
    }
}