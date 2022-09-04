namespace CloneInstagramAPI.Application.Posts.Common
{
    public record PostResult
    (
        Guid Id,
        string Content,
        string? Description,
        string? Avatar,
        string Username,
        int CountLike,
        int CountSave,
        bool IsLike,
        bool IsSave,
        DateTimeOffset CreatedAt
    );
}