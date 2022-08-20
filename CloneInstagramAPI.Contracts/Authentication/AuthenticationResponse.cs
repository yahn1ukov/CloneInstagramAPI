namespace CloneInstagramAPI.Contracts.Authentication
{
    public record AuthenticationResponse
    (
        string Token,
        string Role
    );
}