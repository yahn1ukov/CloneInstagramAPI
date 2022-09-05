namespace CloneInstagramAPI.Contracts.User
{
    public record GetUserResponse
    (
        Guid Id,
        string Email,
        string FullName,
        string Username,
        string? Avatar,
        string? WebSite,
        string? PhoneNumber,
        string? Biography
    );
}