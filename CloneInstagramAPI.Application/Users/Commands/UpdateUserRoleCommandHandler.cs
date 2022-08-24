using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using CloneInstagramAPI.Domain.Enums;
using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserRoleCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(UpdateUserRoleCommand command, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetById(command.UserId) is not User user)
            {
                throw new UserNotFoundException();
            }

            if (user.Role.Equals(UserRole.ADMIN))
            {
                throw new UserAdminNotChangeRoleException();
            }

            if (Enum.GetName(typeof(UserRole), command.NewRole) is null)
            {
                throw new UserRoleNotFoundException();
            }

            user.Role = (UserRole)command.NewRole;

            await _userRepository.Update(user);

            return true;
        }
    }
}