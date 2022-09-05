using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public record UpdatePostSetLikeByIdCommand
    (
        Guid PostId
    ) : IRequest<bool>;
}