using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public record UpdatePostSetLikeUserByIdCommand(Guid PostId) : IRequest<bool>;
}