namespace CloneInstagramAPI.Contracts.User
{
    public record ProfileResponse
    (
        Guid Id,
        string Email,
        string FullName,
        string UserName,
        string Avatar,
        string? WebSite,
        string? PhoneNumber,
        string? Biography,
        int CountPosts,
        int CountFollowers,
        int CountFollowing
    );
}