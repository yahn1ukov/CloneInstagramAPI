using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public record UpdateUserCommand
    (
        string? Avavtar,
        string FullName,
        string UserName,
        string? WebSite,
        string? Biography,
        string Email,
        string? PhoneNumber,
        string? Gender
    ) : IRequest<bool>;
}