using CloneInstagramAPI.Application.Rooms.Common;
using MediatR;

namespace CloneInstagramAPI.Application.Rooms.Queries
{
    public record GetAllRoomMessagesByIdQuery
    (
        Guid RoomId
    ) : IRequest<ICollection<GetAllMessagesResult>>;
}