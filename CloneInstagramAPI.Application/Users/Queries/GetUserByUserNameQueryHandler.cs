using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Application.Users.Common;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Users.Queries
{
    public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByUserNameQuery, ProfileResult>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByUserNameQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ProfileResult> Handle(GetUserByUserNameQuery query, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetByUserName(query.UserName) is not User user)
            {
                throw new UserNotFoundException();
            }

            return new ProfileResult
            (
                user.Id,
                user.Email,
                user.FullName,
                user.UserName,
                user.Avatar,
                user.WebSite,
                user.PhoneNumber,
                user.Biography
            );
        }
    }
}