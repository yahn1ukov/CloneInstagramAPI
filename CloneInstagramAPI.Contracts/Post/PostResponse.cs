using CloneInstagramAPI.Contracts.Comment;

namespace CloneInstagramAPI.Contracts.Post
{
    public record PostResponse
    (
        string UserName,
        string Content,
        int CountLikes,
        int CountComments,
        List<CommentResponse> Comments,
        DateTimeOffset CreatedAt
    );
}