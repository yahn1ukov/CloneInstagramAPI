namespace CloneInstagramAPI.Contracts.Post
{
    public record GetAllCommentsResponse
    (
        Guid Id,
        string Message,
        string Username,
        string? Avatar,
        DateTimeOffset CreatedAt
    );
}