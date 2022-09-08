using CloneInstagramAPI.Domain.Entities;

namespace CloneInstagramAPI.Application.Persistence
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        Task<ICollection<Post>> GetAllWithoutUsers();
        Task<ICollection<Post>> GetAllUserById(Guid userId);
        Task<ICollection<Post>> GetAllLikesUserById(Guid userId);
        Task<ICollection<Post>> GetAllSavesUserById(Guid userId);
    }
}