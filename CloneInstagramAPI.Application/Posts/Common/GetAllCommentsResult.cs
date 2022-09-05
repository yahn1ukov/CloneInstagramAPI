namespace CloneInstagramAPI.Application.Posts.Common
{
    public record GetAllCommentsResult
    (
        Guid Id,
        string Message,
        string Username,
        string? Avatar,
        DateTimeOffset CreatedAt
    );
}