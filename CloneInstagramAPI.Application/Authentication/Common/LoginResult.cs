namespace CloneInstagramAPI.Application.Authentication.Common
{
    public record LoginResult
    (
        string Token,
        string Role
    );
}