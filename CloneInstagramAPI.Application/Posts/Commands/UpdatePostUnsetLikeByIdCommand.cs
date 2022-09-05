using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public record UpdatePostUnsetLikeByIdCommand
    (
        Guid PostId
    ) : IRequest<bool>; 
}