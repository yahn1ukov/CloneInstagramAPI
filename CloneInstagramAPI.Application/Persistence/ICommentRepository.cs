using CloneInstagramAPI.Domain.Entities;

namespace CloneInstagramAPI.Application.Persistence
{
    public interface ICommentRepository : IPostActionRepository<Comment>
    {
        Task<Comment?> Get(Guid commentId);
    }
}