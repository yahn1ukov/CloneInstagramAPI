using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public record UpdatePostAddCommentCommand(Guid PostId, string Message) : IRequest<bool>;
}