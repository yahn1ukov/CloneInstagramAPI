using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public class DeleteCurrentUserByIdCommandHandler : IRequestHandler<DeleteCurrentUserByIdCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public DeleteCurrentUserByIdCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteCurrentUserByIdCommand command, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetById() is not User user)
            {
                throw new UserNotFoundException();
            }

            await _userRepository.Delete(user);
            return true;
        }
    }
}