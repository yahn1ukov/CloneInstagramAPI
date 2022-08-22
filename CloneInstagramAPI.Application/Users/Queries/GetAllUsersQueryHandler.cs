using AutoMapper;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Application.Users.Common;
using MediatR;

namespace CloneInstagramAPI.Application.Users.Queries
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<AllUsersResult>>
    {
        private readonly IUserRepository _userRpository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUserRepository userRpository, IMapper mapper)
        {
            _userRpository = userRpository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AllUsersResult>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
        {
            var users = await _userRpository.GetAll();

            return users
                .Select(u => _mapper.Map<AllUsersResult>(u))
                .ToList();
        }
    }
}