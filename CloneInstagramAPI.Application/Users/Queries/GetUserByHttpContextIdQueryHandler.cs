using AutoMapper;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Application.Users.Common;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Users.Queries
{
    public class GetUserByHttpContextIdQueryHandler : IRequestHandler<GetUserByHttpContextIdQuery, GetUserForNavbarResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByHttpContextIdQueryHandler
        (
            IUserRepository userRepository,
            IMapper mapper
        )
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserForNavbarResult> Handle(GetUserByHttpContextIdQuery query, CancellationToken cancellationToken)
        {
            if (await _userRepository.Get() is not User user)
            {
                throw new UserNotFoundException();
            }

            return _mapper.Map<GetUserForNavbarResult>(user);
        }
    }
}