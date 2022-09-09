using AutoMapper;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using CloneInstagramAPI.Domain.Enums;
using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public class UpdateUserByHttpContextIdCommandHandler : IRequestHandler<UpdateUserByHttpContextIdCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserByHttpContextIdCommandHandler
        (
            IUserRepository userRepository,
            IMapper mapper
        )
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateUserByHttpContextIdCommand command, CancellationToken cancellationToken)
        {
            if (await _userRepository.Get() is not User user)
            {
                throw new UserNotFoundException();
            }

            switch (command.Gender)
            {
                case null:
                    user.Gender = null;
                    break;
                case 0:
                    user.Gender = (UserGender)command.Gender;
                    break;
                case 1:
                    user.Gender = (UserGender)command.Gender;
                    break;
                default:
                    throw new UserGenderNotFoundException();
            }

            var updatedUser = _mapper.Map(command, user);

            await _userRepository.Update(updatedUser);

            return true;
        }
    }
}