using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public record UpdateUserUnbanByIdCommand
    (
        Guid UserId
    ) : IRequest<bool>;
}