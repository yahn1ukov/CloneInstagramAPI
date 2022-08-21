using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public record DeleteUserByIdCommand(Guid UserId) : IRequest<bool>;
}