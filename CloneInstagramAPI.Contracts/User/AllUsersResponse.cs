namespace CloneInstagramAPI.Contracts.User
{
    public record AllUsersResponse
    (
        Guid Id,
        string Email,
        string FullName,
        string UserName,
        string Role,
        string? Gender,
        string? Avatar,
        DateTimeOffset CreatedAt
    );
}