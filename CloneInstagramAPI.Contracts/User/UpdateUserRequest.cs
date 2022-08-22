namespace CloneInstagramAPI.Contracts.User
{
    public record UpdateUserRequest
    (
        string? Avavtar,
        string FullName,
        string UserName,
        string? WebSite,
        string? Biography,
        string Email,
        string? PhoneNumber,
        string? Gender
    );
}