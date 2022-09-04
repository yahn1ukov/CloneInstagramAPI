using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public record UpdatePostSetLikeCommand(Guid PostId) : IRequest<bool>;
}