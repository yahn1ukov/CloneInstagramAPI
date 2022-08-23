using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public record BanUserByIdCommand(Guid UserId) : IRequest<bool>;
}