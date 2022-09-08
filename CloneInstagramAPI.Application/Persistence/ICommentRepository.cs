using CloneInstagramAPI.Domain.Entities;

namespace CloneInstagramAPI.Application.Persistence
{
    public interface ICommentRepository : IActionRepository<Comment>
    {
        Task<Comment?> Get(Guid commentId);
    }
}