using CloneInstagramAPI.Application.Authentication.Common;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Common.Interfaces.Authentication;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Authentication.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResult>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IPasswordHashGenerator _passwordHashGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler
        (
            IJwtTokenGenerator jwtTokenGenerator,
            IPasswordHashGenerator passwordHashGenerator,
            IUserRepository userRepository
        )
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _passwordHashGenerator = passwordHashGenerator;
            _userRepository = userRepository;
        }

        public async Task<LoginResult> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetByUsername(query.Username) is not User user)
            {
                throw new UserNotFoundException();
            }

            if (!_passwordHashGenerator.VerifyPasswordHash(query.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new UserInvalidPasswordException();
            }

            if (user.IsBanned)
            {
                throw new UserIsBannedException();
            }

            if (user.IsDeactivated)
            {
                throw new UserIsDeactivatedException();
            }

            var token = _jwtTokenGenerator.GeneratorToken(user);

            return new LoginResult(token, user.Role.ToString());
        }
    }
}