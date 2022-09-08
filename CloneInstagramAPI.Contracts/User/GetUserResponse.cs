namespace CloneInstagramAPI.Contracts.User
{
    public record GetUserResponse
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