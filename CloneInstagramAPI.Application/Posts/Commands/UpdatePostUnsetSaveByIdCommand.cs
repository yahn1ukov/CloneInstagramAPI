using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public record UpdatePostUnsetSaveByIdCommand
    (
        Guid PostId
    ) : IRequest<bool>;
}