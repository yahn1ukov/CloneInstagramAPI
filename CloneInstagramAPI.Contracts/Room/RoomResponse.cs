using CloneInstagramAPI.Contracts.Message;

namespace CloneInstagramAPI.Contracts.Room
{
    public record RoomResponse
    (
        Guid Id,
        string? PenPalUserAvatar,
        List<MessageResponse> Messages,
        DateTimeOffset CreatedAt
    );
}
