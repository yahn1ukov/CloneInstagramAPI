namespace CloneInstagramAPI.Contracts.Authentication
{
    public record RegistrationRequest
    (
        string Email,
        string FullName,
        string UserName,
        string Password
    );
}