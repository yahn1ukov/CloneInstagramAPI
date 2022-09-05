namespace CloneInstagramAPI.Application.Posts.Common
{
    public record AllPostCommentsResult
    (
        Guid Id,
        string Message,
        DateTimeOffset CreatedAt
    );
}