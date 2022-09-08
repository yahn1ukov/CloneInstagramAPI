namespace CloneInstagramAPI.Application.Posts.Common
{
    public record GetAllPostsFollowingResult
    (
        Guid Id,
        string Content,
        string? Description,
        string? Avatar,
        string Username,
        int CountLikes,
        int CountSaves,
        int CountComments,
        bool IsLike,
        bool IsSave,
        DateTimeOffset CreatedAt
    );
}