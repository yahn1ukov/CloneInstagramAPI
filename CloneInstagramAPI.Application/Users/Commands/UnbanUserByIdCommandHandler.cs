using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public class UnbanUserByIdCommandHandler : IRequestHandler<UnbanUserByIdCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public UnbanUserByIdCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(UnbanUserByIdCommand command, CancellationToken cancellationToken)
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