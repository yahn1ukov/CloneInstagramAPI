using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public record UpdateUserRoleCommand
    (
        Guid UserId,
        int NewRole
    ) : IRequest<bool>;
}