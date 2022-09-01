namespace CloneInstagramAPI.Application.Posts.Common
{
    public record PostResult
    (
        Guid Id,
        string Content,
        string? Description,
        string? Avatar,
        string Username,
        int CountLikes,
        int CountSave,
        bool IsLike,
        bool IsSave,
        DateTimeOffset CreatedAt
    );
}