using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public class DeleteUserByHttpContextIdCommandHandler : IRequestHandler<DeleteUserByHttpContextIdCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserByHttpContextIdCommandHandler
        (
            IUserRepository userRepository
        )
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteUserByHttpContextIdCommand command, CancellationToken cancellationToken)
        {
            if (await _userRepository.Get() is not User user)
            {
                throw new UserNotFoundException();
            }

            await _userRepository.Delete(user);

            return true;
        }
    }
}