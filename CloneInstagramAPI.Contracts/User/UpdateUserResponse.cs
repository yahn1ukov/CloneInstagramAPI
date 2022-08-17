namespace CloneInstagramAPI.Contracts.User
{
    public record UpdateUserResponse
    (
        string? Avatar,
        string FullName,
        string UserName,
        string? WebSite,
        string? Biography,
        string Email,
        string? PhoneNumber,
        string Gender
    );
}