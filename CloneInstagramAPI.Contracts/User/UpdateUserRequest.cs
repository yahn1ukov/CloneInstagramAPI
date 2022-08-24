namespace CloneInstagramAPI.Contracts.User
{
    public record UpdateUserRequest
    (
        string? Avavtar,
        string FullName,
        string Username,
        string? WebSite,
        string? Biography,
        string Email,
        string? PhoneNumber,
        int? Gender
    );
}