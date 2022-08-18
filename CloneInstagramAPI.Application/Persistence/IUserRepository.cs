using CloneInstagramAPI.Domain.Entities;

namespace CloneInstagramAPI.Application.Persistence
{
    public interface IUserRepository
    {
        Task<User?> FindByEmail(string email);
        Task<User?> FindByUserName(string username);
        Task<User?> FindByGuid(Guid id);
        Task Create(User user);
        Task<User?> Get(Guid id);
        Task<IEnumerable<User>> GetAll();
    }
}