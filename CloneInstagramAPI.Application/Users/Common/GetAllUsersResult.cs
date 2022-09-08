namespace CloneInstagramAPI.Application.Users.Common
{
    public record GetAllUsersResult
    (
        Guid Id,
        string Email,
        string FullName,
        string Username,
        string Role,
        string? Avatar,
        DateTimeOffset CreatedAt
    );
}