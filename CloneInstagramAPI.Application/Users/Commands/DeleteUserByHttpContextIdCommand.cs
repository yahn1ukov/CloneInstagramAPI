using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public record DeleteUserByHttpContextIdCommand() : IRequest<bool>;
}