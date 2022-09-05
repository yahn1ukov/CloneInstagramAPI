namespace CloneInstagramAPI.Contracts.Post
{
    public record AllPostCommentsResponse
    (
        Guid Id,
        string Message,
        DateTimeOffset CreatedAt
    );
}