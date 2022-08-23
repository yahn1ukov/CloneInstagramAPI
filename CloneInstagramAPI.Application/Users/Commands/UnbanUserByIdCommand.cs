using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public record UnbanUserByIdCommand(Guid UserId) : IRequest<bool>;
}