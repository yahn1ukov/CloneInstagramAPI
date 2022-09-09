using CloneInstagramAPI.Application.Rooms.Common;
using MediatR;

namespace CloneInstagramAPI.Application.Rooms.Queries
{
    public record GetAllRoomsUserByHttpContextIdQuery() : IRequest<ICollection<GetAllRoomsResult>>;
}