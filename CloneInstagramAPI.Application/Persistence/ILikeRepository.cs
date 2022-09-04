using CloneInstagramAPI.Domain.Entities;

namespace CloneInstagramAPI.Application.Persistence
{
    public interface ILikeRepository
    {
        Task<Like> Get(Guid userId, Guid postId);
        Task Set(Like like);
        Task Unset(Like like);
    }
}