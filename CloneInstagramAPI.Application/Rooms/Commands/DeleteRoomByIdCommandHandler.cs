using CloneInstagramAPI.Application.Common.Exception.Error.Room;
using CloneInstagramAPI.Application.Common.Exception.Error.User;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using MediatR;

namespace CloneInstagramAPI.Application.Rooms.Commands
{
    public class DeleteRoomByIdCommandHandler : IRequestHandler<DeleteRoomByIdCommand, bool>
    {
        private readonly IRoomRepository _roomRepository;

        public DeleteRoomByIdCommandHandler
        (
            IRoomRepository roomRepository
        )
        {
            _roomRepository = roomRepository;
        }

        public async Task<bool> Handle(DeleteRoomByIdCommand command, CancellationToken cancellationToken)
        {
            if(await _roomRepository.GetById(command.RoomId) is not Room room)
            {
                throw new RoomNotFoundException();
            }

            await _roomRepository.Delete(room);

            return true;
        }
    }
}