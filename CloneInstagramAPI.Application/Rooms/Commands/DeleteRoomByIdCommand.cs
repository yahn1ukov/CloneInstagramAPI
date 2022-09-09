using MediatR;

namespace CloneInstagramAPI.Application.Rooms.Commands
{
    public record DeleteRoomByIdCommand
    (
        Guid RoomId
    ) : IRequest<bool>;
}