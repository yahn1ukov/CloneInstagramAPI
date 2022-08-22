using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public record UpdateUserRoleCommand
    (
        Guid Id,
        int NewRole
    ) : IRequest<bool>;
}