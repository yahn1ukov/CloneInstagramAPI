using CloneInstagramAPI.Domain.Entities;

namespace CloneInstagramAPI.Application.Persistence
{
    public interface IRoomRepository : IBaseRepository<Room> 
    {
        Task<Room?> GetById(Guid userHttpContextId, Guid userId);
        Task<ICollection<Room>> GetAllById(Guid userId);
    }
}