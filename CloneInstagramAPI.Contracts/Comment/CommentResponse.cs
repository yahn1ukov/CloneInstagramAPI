namespace CloneInstagramAPI.Contracts.Comment
{
    public record CommentResponse
    (
        string UserName,
        string Text,
        DateTimeOffset CreatedAt
    );
}