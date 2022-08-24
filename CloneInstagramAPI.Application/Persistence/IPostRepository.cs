using CloneInstagramAPI.Domain.Entities;

namespace CloneInstagramAPI.Application.Persistence
{
    public interface IPostRepository
    {
        Task Create(Post post);
        Task<Post?> GetById(Guid id);
        Task<IEnumerable<Post>> GetAll();
        Task<IEnumerable<Post>> GetAllUsersById(Guid id);
        Task Delete(Post post);
    }
}