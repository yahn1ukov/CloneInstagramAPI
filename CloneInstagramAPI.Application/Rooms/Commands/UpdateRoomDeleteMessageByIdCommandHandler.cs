using CloneInstagramAPI.Application.Common.Exception.Error.Room;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Rooms.Commands
{
    public class UpdateRoomDeleteMessageByIdCommandHandler : IRequestHandler<UpdateRoomDeleteMessageByIdCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMessageRepository _messageRepository;

        public UpdateRoomDeleteMessageByIdCommandHandler
        (
            IUserRepository userRepository,
            IMessageRepository messageRepository
        )
        {
            _userRepository = userRepository;
            _messageRepository = messageRepository;
        }

        public async Task<bool> Handle(UpdateRoomDeleteMessageByIdCommand command, CancellationToken cancellationToken)
        {
            if(await _userRepository.Get() is not User user)
            {
                throw new UserNotFoundException();
            }

            if(await _messageRepository.GetById(command.MessageId) is not Message message)
            {
                throw new RoomMessageNotFoundException();
            }

            if(message.UserId != user.Id)
            {
                throw new RoomMessageCannotBeDeletedException();
            }

            await _messageRepository.Remove(message);

            return true;
        }
    }
}