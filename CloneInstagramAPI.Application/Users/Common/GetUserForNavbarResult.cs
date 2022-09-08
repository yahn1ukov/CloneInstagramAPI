namespace CloneInstagramAPI.Application.Users.Common
{
    public record GetUserForNavbarResult
    (
        string Username,
        string? Avatar
    );
}