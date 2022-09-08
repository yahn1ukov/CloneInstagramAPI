using AutoMapper;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Application.Users.Common;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Users.Queries
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, ICollection<GetAllUsersResult>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler
        (
            IUserRepository userRepository,
            IMapper mapper
        )
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<GetAllUsersResult>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAll();

            return users
                .Select(u => _mapper.Map<GetAllUsersResult>(u))
                .ToList();
        }
    }
}