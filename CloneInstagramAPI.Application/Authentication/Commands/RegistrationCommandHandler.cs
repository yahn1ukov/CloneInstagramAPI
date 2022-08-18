using CloneInstagramAPI.Application.Authentication.Common;
using CloneInstagramAPI.Application.Common.Interfaces.Authentication;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Common.Errors;
using CloneInstagramAPI.Domain.Entities;
using CloneInstagramAPI.Domain.Enums;
using ErrorOr;
using MediatR;

namespace CloneInstagramAPI.Application.Authentication.Commands
{
    public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, ErrorOr<AuthenticationResult>>
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

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegistrationCommand command, CancellationToken cancellationToken)
        {
            if (await _userRepository.FindByEmail(command.Email) is not null)
            {
                return Errors.User.AlreadyExists;
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

            return new AuthenticationResult(Token: "", Role: "");
        }
    }
}