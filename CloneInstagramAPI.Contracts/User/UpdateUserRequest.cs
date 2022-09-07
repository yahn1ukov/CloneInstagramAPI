namespace CloneInstagramAPI.Contracts.User
{
    public record UpdateUserRequest
    (
        string? Avatar,
        string FullName,
        string Username,
        string? WebSite,
        string? Biography,
        string Email,
        string? PhoneNumber,
        int? Gender
    );
}