namespace CloneInstagramAPI.Application.Users.Common
{
    public record AllUsersResult
    (
        Guid Id,
        string Email,
        string FullName,
        string Username,
        string Role,
        string? Gender,
        string? Avatar,
        DateTimeOffset CreatedAt
    );
}