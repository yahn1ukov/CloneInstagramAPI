namespace CloneInstagramAPI.Application.Posts.Common
{
    public record PostResult
    (
        Guid Id,
        string Content,
        string? Description,
        string? Avatar,
        string Username,
        DateTimeOffset CreatedAt
    );
}