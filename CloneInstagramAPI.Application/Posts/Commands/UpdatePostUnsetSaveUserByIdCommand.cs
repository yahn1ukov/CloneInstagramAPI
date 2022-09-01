using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public record UpdatePostUnsetSaveUserByIdCommand(Guid PostId) : IRequest<bool>;
}