using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public record UpdatePostSetSaveUserByIdCommand(Guid PostId) : IRequest<bool>;
}