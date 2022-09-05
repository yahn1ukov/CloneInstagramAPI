using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public record UpdateUserRoleByIdCommand
    (
        Guid UserId,
        int NewRole
    ) : IRequest<bool>;
}