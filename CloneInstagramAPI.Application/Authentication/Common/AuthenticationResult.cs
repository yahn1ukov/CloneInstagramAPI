namespace CloneInstagramAPI.Application.Authentication.Common
{
    public record AuthenticationResult
    (
        string Token,
        string Role
    );
}