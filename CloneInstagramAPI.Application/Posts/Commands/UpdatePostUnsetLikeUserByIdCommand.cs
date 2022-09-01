using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public record UpdatePostUnsetLikeUserByIdCommand(Guid PostId) : IRequest<bool>;
}