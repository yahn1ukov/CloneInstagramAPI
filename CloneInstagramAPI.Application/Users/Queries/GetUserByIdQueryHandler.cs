using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Application.Users.Common;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Users.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ProfileResult>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository; 
        }
        
        public async Task<ProfileResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetById() is not User user)
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