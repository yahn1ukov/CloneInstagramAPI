namespace CloneInstagramAPI.Contracts.Authentication
{
    public record LoginResponse
    (
        string Token,
        string Role
    );
}