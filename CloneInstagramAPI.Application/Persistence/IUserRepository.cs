using CloneInstagramAPI.Domain.Entities;

namespace CloneInstagramAPI.Application.Persistence
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> ExistsAdmin();
        Task<bool> ExistsByEmail(string email);
        Task<bool> ExistsByUsername(string username);
        Task<User?> GetById();
        Task<User?> GetByUsername(string username);
    }
}