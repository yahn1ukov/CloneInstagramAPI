namespace CloneInstagramAPI.Application.Authentication.Queries
{
    public record LoginQuery
    (
        string UserName,
        string Password
    );
}