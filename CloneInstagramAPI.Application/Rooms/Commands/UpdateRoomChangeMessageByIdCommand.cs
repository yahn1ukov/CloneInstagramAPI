using MediatR;

namespace CloneInstagramAPI.Application.Rooms.Commands
{
    public record UpdateRoomChangeMessageByIdCommand
    (
        Guid MessageId,
        string  Text
    ) : IRequest<bool>;
}