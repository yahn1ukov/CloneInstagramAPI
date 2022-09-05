using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public record UpdatePostDeleteCommentByIdCommand
    (
        Guid CommentId
    ) : IRequest<bool>;
}