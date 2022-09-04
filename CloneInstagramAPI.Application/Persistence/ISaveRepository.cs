using CloneInstagramAPI.Domain.Entities;

namespace CloneInstagramAPI.Application.Persistence
{
    public interface ISaveRepository
    {
        Task<Save> Get(Guid userId, Guid postId);
        Task Set(Save save);
        Task Unset(Save save);
    }
}