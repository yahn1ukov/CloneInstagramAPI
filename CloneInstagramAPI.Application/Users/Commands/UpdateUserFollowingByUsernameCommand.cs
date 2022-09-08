using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public record UpdateUserFollowingByUsernameCommand
    (
        string Username
    ) : IRequest<bool>;
}