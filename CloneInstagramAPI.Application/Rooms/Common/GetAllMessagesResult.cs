namespace CloneInstagramAPI.Application.Rooms.Common
{
    public record GetAllMessagesResult
    (
        Guid Id,
        string Text,
        string? Avatar,
        string Username,
        bool IsEdited,
        DateTimeOffset CreatedAt
    );
}