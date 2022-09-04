using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public record UpdatePostUnsetSaveCommand(Guid PostId) : IRequest<bool>;
}