using MediatR;

namespace CloneInstagramAPI.Application.Rooms.Commands
{
    public record CreateRoomCommand
    (
        string Username
    ) : IRequest<bool>;
}