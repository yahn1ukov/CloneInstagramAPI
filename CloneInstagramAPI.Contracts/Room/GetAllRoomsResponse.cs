namespace CloneInstagramAPI.Contracts.Room
{
    public record GetAllRoomsResponse
    (
        Guid Id,
        string? Avatar,
        string Username
    );
}