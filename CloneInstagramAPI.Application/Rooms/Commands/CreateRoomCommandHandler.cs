using CloneInstagramAPI.Application.Common.Exception.Error.Room;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Rooms.Commands
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoomRepository _roomRepository;

        public CreateRoomCommandHandler
        (
            IUserRepository userRepository,
            IRoomRepository roomRepository
        )
        {
            _userRepository = userRepository;
            _roomRepository = roomRepository;
        }

        public async Task<bool> Handle(CreateRoomCommand command, CancellationToken cancellationToken)
        {
            if(await _userRepository.Get() is not User userHttpContext)
            {
                throw new UserNotFoundException();
            }

            if(await _userRepository.GetByUsername(command.Username) is not User user)
            {
                throw new UserNotFoundException();
            }

            if(await _roomRepository.GetById(userHttpContext.Id, user.Id) is not null)
            {
                throw new RoomAlreadyExistsException();
            }

            var roomHttpContext = new Room
            {
                UserId = userHttpContext.Id,
                PenPalUserId = user.Id
            };

            var room = new Room
            {
                UserId = user.Id,
                PenPalUserId = userHttpContext.Id
            };

            await _roomRepository.Create(roomHttpContext);

            await _roomRepository.Create(room);

            return true;
        }
    }
}