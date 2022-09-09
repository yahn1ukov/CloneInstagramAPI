using MediatR;

namespace CloneInstagramAPI.Application.Rooms.Commands
{
    public record UpdateRoomAddMessageByIdCommand
    (
        Guid RoomId,
        string Text
    ) : IRequest<bool>;
}