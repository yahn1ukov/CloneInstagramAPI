using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public record CreatePostCommand
    (
        string Content,
        string? Description
    ) : IRequest<bool>;
}