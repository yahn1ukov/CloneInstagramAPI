using CloneInstagramAPI.Application.Authentication.Common;
using CloneInstagramAPI.Application.Common.Interfaces.Authentication;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Common.Errors;
using CloneInstagramAPI.Domain.Entities;
using ErrorOr;
using MediatR;

namespace CloneInstagramAPI.Application.Authentication.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IPasswordHashGenerator _passwordHashGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(
            IJwtTokenGenerator jwtTokenGenerator, 
            IPasswordHashGenerator passwordHashGenerator, 
            IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _passwordHashGenerator = passwordHashGenerator;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            if (await _userRepository.FindByUserName(query.UserName) is not User user)
            {
                return Errors.User.NotFound;
            }

            if (!_passwordHashGenerator.VerifyPasswordHash(query.Password, user.PasswordHash, user.PasswordSalt))
            {
                return Errors.User.InvalidPassword;
            }

            var token = _jwtTokenGenerator.GeneratorToken(user);

            return new AuthenticationResult(Token: token, Role: user.Role.ToString());
        }
    }
}