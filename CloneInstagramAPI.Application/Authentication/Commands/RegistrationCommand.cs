using MediatR;

namespace CloneInstagramAPI.Application.Authentication.Commands
{
    public record RegistrationCommand
    (
        string Email,
        string FullName,
        string Username,
        string Password
    ) : IRequest<bool>;
}