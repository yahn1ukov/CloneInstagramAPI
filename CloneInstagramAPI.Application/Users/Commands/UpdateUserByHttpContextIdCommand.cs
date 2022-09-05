using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public record UpdateUserByHttpContextIdCommand
    (
        string? Avatar,
        string FullName,
        string Username,
        string? WebSite,
        string? Biography,
        string Email,
        string? PhoneNumber,
        int? Gender
    ) : IRequest<bool>;
}