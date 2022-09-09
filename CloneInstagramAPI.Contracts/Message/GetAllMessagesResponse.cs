namespace CloneInstagramAPI.Contracts.Message
{
    public record GetAllMessagesResponse
    (
        Guid Id,
        string Text,
        string? Avatar,
        string Username,
        bool IsEdited,
        DateTimeOffset CreatedAt
    );
}