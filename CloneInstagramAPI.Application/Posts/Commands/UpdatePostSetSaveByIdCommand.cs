using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public record UpdatePostSetSaveByIdCommand
    (
        Guid PostId
    ) : IRequest<bool>;
}