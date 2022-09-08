using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Common.Interfaces.Authentication;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public class UpdateUserPasswordByHttpContextIdCommandHandler : IRequestHandler<UpdateUserPasswordByHttpContextIdCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHashGenerator _passwordHashGenerator;

        public UpdateUserPasswordByHttpContextIdCommandHandler
        (
            IUserRepository userRepository,
            IPasswordHashGenerator passwordHashGenerator
        )
        {
            _userRepository = userRepository;
            _passwordHashGenerator = passwordHashGenerator;
        }

        public async Task<bool> Handle(UpdateUserPasswordByHttpContextIdCommand command, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetById() is not User user)
            {
                throw new UserNotFoundException();
            }

            if (!_passwordHashGenerator.VerifyPasswordHash(command.OldPassword, user.PasswordHash, user.PasswordSalt))
            {
                throw new UserInvalidPasswordException();
            }

            if (command.OldPassword.Equals(command.NewPassword))
            {
                throw new UserOldPasswordSameNewPasswordException();
            }

            if (!command.NewPassword.Equals(command.ConfirmNewPassword))
            {
                throw new UserNewPasswordNotSameConfirmedNewPasswordException();
            }

            _passwordHashGenerator.GeneratePasswordHash(command.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _userRepository.Update(user);

            return true;
        }
    }
}