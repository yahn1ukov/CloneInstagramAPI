using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public record UpdateCurrentUserPasswordCommand
    (
        string OldPassword,
        string NewPassword,
        string ConfirmedNewPassword
    ) : IRequest<bool>;
}