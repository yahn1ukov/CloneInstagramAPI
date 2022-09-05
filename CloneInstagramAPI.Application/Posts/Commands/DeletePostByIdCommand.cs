using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public record DeletePostByIdCommand
    (
        Guid PostId
    ) : IRequest<bool>;
}