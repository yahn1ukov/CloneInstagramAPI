using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Application.Users.Common;
using MediatR;

namespace CloneInstagramAPI.Application.Users.Queries
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<AllUsersResult>>
    {
        private readonly IUserRepository _userRpository;

        public GetAllUsersQueryHandler(IUserRepository userRpository)
        {
            _userRpository = userRpository;
        }

        public async Task<IEnumerable<AllUsersResult>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRpository.GetAll();

            return users
                .Select(u => new AllUsersResult
                    (
                        u.Id,
                        u.Email,
                        u.FullName,
                        u.UserName,
                        u.Role.ToString(),
                        u.Gender.ToString(),
                        u.Avatar,
                        u.CreatedAt
                    )
                )
                .ToList();
        }
    }
}