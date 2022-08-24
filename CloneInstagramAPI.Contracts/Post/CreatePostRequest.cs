namespace CloneInstagramAPI.Contracts.Post
{
    public record CreatePostRequest
    (
        string Content,
        string? Description

    );
}