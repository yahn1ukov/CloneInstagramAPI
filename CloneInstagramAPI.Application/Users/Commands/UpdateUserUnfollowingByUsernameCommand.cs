using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public record UpdateUserUnfollowingByUsernameCommand
    (
        string Username
    ) : IRequest<bool>;
}