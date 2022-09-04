using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public record UpdatePostUnsetLikeCommand(Guid PostId) : IRequest<bool>; 
}