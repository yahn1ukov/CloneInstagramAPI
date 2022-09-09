namespace CloneInstagramAPI.Application.Rooms.Common
{
    public record GetAllRoomsResult
    (
        Guid Id,
        string? Avatar,
        string Username
    );
}