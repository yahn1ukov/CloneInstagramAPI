using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;

namespace CloneInstagramAPI.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> users = new List<User>();

        public async Task<User?> FindByEmail(string email)
        {
            return users.SingleOrDefault(u => u.Email.ToLower().Equals(email.ToLower()));
        }

        public async Task<User?> FindByUserName(string username)
        {
            return users.SingleOrDefault(u => u.UserName.ToLower().Equals(username.ToLower()));
        }

        public async Task<User?> FindByGuid(Guid id)
        {
            return users.SingleOrDefault(u => u.Id == id);
        }

        public async Task Create(User user)
        {
            users.Add(user);
        }

        public async Task<User?> Get(Guid id)
        {
            return await FindByGuid(id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return users;
        }
    }
}