namespace CloneInstagramAPI.Application.Users.Common
{
    public record GetAllFollowersResult
    (
        Guid Id,
        string Username,
        string FullName
    );
}