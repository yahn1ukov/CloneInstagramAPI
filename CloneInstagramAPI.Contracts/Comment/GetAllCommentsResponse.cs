namespace CloneInstagramAPI.Contracts.Comment
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