using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public record UpdateUserPasswordCommand
    (
        string OldPassword,
        string NewPassword,
        string ConfirmedNewPassword
    ) : IRequest<bool>;
}