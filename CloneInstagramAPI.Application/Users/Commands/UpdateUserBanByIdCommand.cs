using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public record UpdateUserBanByIdCommand
    (
        Guid UserId
    ) : IRequest<bool>;
}