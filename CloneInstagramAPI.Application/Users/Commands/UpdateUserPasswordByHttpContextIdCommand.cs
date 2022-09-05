using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public record UpdateUserPasswordByHttpContextIdCommand
    (
        string OldPassword,
        string NewPassword,
        string ConfirmedNewPassword
    ) : IRequest<bool>;
}