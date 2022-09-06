using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public record UpdatePostAddCommentByIdCommand
    (
        Guid PostId,
        string Message
    ) : IRequest<bool>;
}