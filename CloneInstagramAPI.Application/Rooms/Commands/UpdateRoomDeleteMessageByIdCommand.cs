using MediatR;

namespace CloneInstagramAPI.Application.Rooms.Commands
{
    public record UpdateRoomDeleteMessageByIdCommand
    (
        Guid MessageId
    ) : IRequest<bool>;
}