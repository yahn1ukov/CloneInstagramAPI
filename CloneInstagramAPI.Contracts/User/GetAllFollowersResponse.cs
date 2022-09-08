namespace CloneInstagramAPI.Contracts.User
{
    public record GetAllFollowersResponse
    (
        Guid Id,
        string Username,
        string FullName
    );
}