using AutoMapper;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Common.Interfaces.Authentication;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using CloneInstagramAPI.Domain.Enums;
using MediatR;

namespace CloneInstagramAPI.Application.Authentication.Commands
{
    public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, bool>
    {
        private readonly IPasswordHashGenerator _passwordHashGenerator;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RegistrationCommandHandler
        (
            IPasswordHashGenerator passwordHashGenerator,
            IUserRepository userRepository,
            IMapper mapper
        )
        {
            _passwordHashGenerator = passwordHashGenerator;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(RegistrationCommand command, CancellationToken cancellationToken)
        {
            if (await _userRepository.ExistsByEmail(command.Email))
            {
                throw new UserSameEmailAlreadyExistsException();
            }

            if (await _userRepository.ExistsByUsername(command.Username))
            {
                throw new UserSameUsernameAlreadyExistsException();
            }

            _passwordHashGenerator.GeneratePasswordHash(command.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = _mapper.Map<User>(command);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            if (!(await _userRepository.ExistsAdmin()))
            {
                user.Role = UserRole.ADMIN;
            }

            await _userRepository.Create(user);

            return true;
        }
    }
}