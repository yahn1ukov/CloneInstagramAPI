namespace CloneInstagramAPI.Contracts.User
{
    public record GetAllUsersResponse
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