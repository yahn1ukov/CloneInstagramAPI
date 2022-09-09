using CloneInstagramAPI.Domain.Entities;

namespace CloneInstagramAPI.Application.Persistence
{
    public interface ICommentRepository : IActionRepository<Comment>
    {
        Task<Comment?> GetById(Guid commentId);
        Task<ICollection<Comment>> GetAllById(Guid postId);
    }
}