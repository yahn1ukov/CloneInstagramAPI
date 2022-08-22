using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetUserByUserNameQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ProfileResult> Handle(GetUserByUserNameQuery query, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetByUserName(query.UserName) is not User user)
            {
                throw new UserNotFoundException();
            }

            return _mapper.Map<ProfileResult>(user);
        }
    }
}