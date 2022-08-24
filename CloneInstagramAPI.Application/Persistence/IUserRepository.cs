using CloneInstagramAPI.Domain.Entities;

namespace CloneInstagramAPI.Application.Persistence
{
    public interface IUserRepository
    {
        Task<bool> ExistsAdmin();
        Task<bool> ExistsByEmail(string email);
        Task<bool> ExistsByUsername(string username);
        Task Create(User user);
        Task<User?> GetById();
        Task<User?> GetById(Guid id);
        Task<User?> GetByUsername(string username);
        Task<IEnumerable<User>> GetAll();
        Task Update(User user);
        Task Delete(User user);
    }
}