using CloneInstagramAPI.Application.Common.Exception.Error.Room;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Rooms.Commands
{
    public class UpdateRoomAddMessageByIdCommandHandler : IRequestHandler<UpdateRoomAddMessageByIdCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMessageRepository _messageRepository;

        public UpdateRoomAddMessageByIdCommandHandler
        (
            IUserRepository userRepository,
            IRoomRepository roomRepository,
            IMessageRepository messageRepository
        )
        {
            _userRepository = userRepository;
            _roomRepository = roomRepository;
            _messageRepository = messageRepository;
        }

        public async Task<bool> Handle(UpdateRoomAddMessageByIdCommand command, CancellationToken cancellationToken)
        {
            if(await _userRepository.Get() is not User user)
            {
                throw new UserNotFoundException();
            }

            if(await _roomRepository.GetById(command.RoomId) is not Room room)
            {
                throw new RoomNotFoundException();
            }

            var message = new Message
            {
                Text = command.Text,
                UserId = user.Id,
                RoomId = room.Id
            };

            await _messageRepository.Add(message);

            return true;
        }
    }
}