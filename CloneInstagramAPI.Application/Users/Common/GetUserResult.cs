namespace CloneInstagramAPI.Application.Users.Common
{
    public record GetUserResult
    (
        string Email,
        string FullName,
        string Username,
        string? Avatar,
        string? WebSite,
        string? PhoneNumber,
        string? Gender,
        string? Biography,
        int CountPosts,
        int CountFollowers,
        int CountFollowing,
        bool isFollowing
    );
}