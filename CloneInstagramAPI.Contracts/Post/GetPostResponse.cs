using CloneInstagramAPI.Contracts.Comment;

namespace CloneInstagramAPI.Contracts.Post
{
    public record GetPostResponse
    (
        Guid Id,
        string Content,
        string? Description,
        string? Avatar,
        string Username,
        int CountLikes,
        int CountSaves,
        int CountComments,
        ICollection<GetAllCommentsResponse> Comments,
        bool IsLike,
        bool IsSave,
        DateTimeOffset CreatedAt
    );
}