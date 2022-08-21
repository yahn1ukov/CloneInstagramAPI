using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Common.Interfaces.Authentication;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Authentication.Commands
{
    public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, bool>
    {
        private readonly IPasswordHashGenerator _passwordHashGenerator;
        private readonly IUserRepository _userRepository;

        public RegistrationCommandHandler(
            IPasswordHashGenerator passwordHashGenerator,
            IUserRepository userRepository)
        {
            _passwordHashGenerator = passwordHashGenerator;
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(RegistrationCommand command, CancellationToken cancellationToken)
        {
            if (await _userRepository.FindByEmail(command.Email))
            {
                throw new UserAlreadyExistsException();
            }

            _passwordHashGenerator.GeneratePasswordHash(command.Password, out byte[] passwordHash, out byte[] passwortSalt);

            var user = new User
            {
                Email = command.Email,
                FullName = command.FullName,
                UserName = command.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwortSalt
            };

            await _userRepository.Create(user);

            return true;
        }
    }
}