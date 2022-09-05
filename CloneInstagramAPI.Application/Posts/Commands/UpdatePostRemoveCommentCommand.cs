using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public record UpdatePostRemoveCommentCommand(Guid PostId) : IRequest<bool>;
}