using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public record UpdatePostByIdCommand
    (
        Guid PostId,
         string Description
    ) : IRequest<bool>;
}