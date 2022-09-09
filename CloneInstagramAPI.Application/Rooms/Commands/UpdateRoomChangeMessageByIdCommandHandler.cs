using CloneInstagramAPI.Application.Common.Exception.Error.Room;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Rooms.Commands
{
    public class UpdateRoomChangeMessageByIdCommandHandler : IRequestHandler<UpdateRoomChangeMessageByIdCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMessageRepository _messageRepository;

        public UpdateRoomChangeMessageByIdCommandHandler
        (
            IUserRepository userRepository,
            IMessageRepository messageRepository
        )
        {
            _userRepository = userRepository;
            _messageRepository = messageRepository;
        }

        public async Task<bool> Handle(UpdateRoomChangeMessageByIdCommand command, CancellationToken cancellationToken)
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
                throw new RoomMessageCannotBeChangedException();
            }

            message.Text = command.Text;
            message.IsEdited = true;

            await _messageRepository.Change(message);

            return true;
        }
    }
}