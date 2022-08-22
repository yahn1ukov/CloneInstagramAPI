using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserByIdCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteUserByIdCommand command, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetById(command.UserId) is not User user)
            {
                throw new UserNotFoundException();
            }

            await _userRepository.Delete(user);

            return true;
        }
    }
}