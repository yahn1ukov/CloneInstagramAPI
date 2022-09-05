using CloneInstagramAPI.Domain.Entities;

namespace CloneInstagramAPI.Application.Posts.Common
{
    public record GetPostResult
    (
        Guid Id,
        string Content,
        string? Description,
        string? Avatar,
        string Username,
        int CountLikes,
        int CountSaves,
        int CountComments,
        IEnumerable<GetAllCommentsResult> Comments,
        bool IsLike,
        bool IsSave,
        DateTimeOffset CreatedAt
    );
}