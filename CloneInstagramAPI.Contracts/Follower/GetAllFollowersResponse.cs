namespace CloneInstagramAPI.Contracts.Follower
{
    public record GetAllFollowersResponse
    (
        Guid Id,
        string Username,
        string FullName
    );
}