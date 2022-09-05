using MediatR;

namespace CloneInstagramAPI.Application.Posts.Commands
{
    public record UpdatePostDescriptionCommand(Guid PostId, string Description) : IRequest<bool>;
}