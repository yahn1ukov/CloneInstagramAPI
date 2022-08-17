namespace CloneInstagramAPI.Contracts.Authentication
{
    public record RegistrationRequest
    (
        string Email,
        string FullName,
        string Username,
        string Password
    );
}