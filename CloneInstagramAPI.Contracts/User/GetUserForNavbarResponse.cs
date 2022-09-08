namespace CloneInstagramAPI.Contracts.User
{
    public record GetUserForNavbarResponse
    (
        string Username,
        string? Avatar
    );
}