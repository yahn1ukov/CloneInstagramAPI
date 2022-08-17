namespace CloneInstagramAPI.Contracts.Message
{
    public record MessageResponse
    (
        Guid Id,
        string? Avatar,
        string Text,
        DateTimeOffset CreatedAt
    );
}