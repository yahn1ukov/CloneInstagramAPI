using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public record UpdatePostSetSaveCommand(Guid PostId) : IRequest<bool>;
}