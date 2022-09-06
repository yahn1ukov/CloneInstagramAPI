using CloneInstagramAPI.Domain.Entities;

namespace CloneInstagramAPI.Application.Persistence
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        Task<IEnumerable<Post>> GetAllWithoutUsers();
        Task<IEnumerable<Post>> GetAllUserById(Guid userId);
        Task<IEnumerable<Post>> GetAllLikesUserById(Guid userId);
        Task<IEnumerable<Post>> GetAllSavesUserById(Guid userId);
    }
}