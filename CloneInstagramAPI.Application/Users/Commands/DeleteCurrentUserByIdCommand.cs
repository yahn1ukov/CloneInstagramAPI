using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public record DeleteCurrentUserByIdCommand() : IRequest<bool>;
}