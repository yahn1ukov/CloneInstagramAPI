namespace CloneInstagramAPI.Contracts.Post
{
    public record PostResponse
    (
        Guid Id,
        string Content,
        string? Description,
        string? Avatar,
        string Username,
        int CountLikes,
        int CountSaves,
        int CountComments,
        IEnumerable<AllPostCommentsResponse> Comments,
        bool IsLike,
        bool IsSave,
        DateTimeOffset CreatedAt
    );
}