using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public class BanUserByIdCommandHandler : IRequestHandler<BanUserByIdCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public BanUserByIdCommandHandler
        (
            IUserRepository userRepository
        )
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(BanUserByIdCommand command, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetById(command.UserId) is not User user)
            {
                throw new UserNotFoundException();
            }

            if (user.IsBanned)
            {
                throw new UserIsBannedException();
            }

            user.IsBanned = true;

            await _userRepository.Update(user);

            return true;
        }
    }
}