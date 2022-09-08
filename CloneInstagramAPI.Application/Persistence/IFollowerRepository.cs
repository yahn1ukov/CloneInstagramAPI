using CloneInstagramAPI.Domain.Entities;

namespace CloneInstagramAPI.Application.Persistence
{
    public interface IFollowerRepository : IActionRepository<Follower>
    {
        public Task<ICollection<Follower>> GetAllFollowers(Guid userId);
        public Task<ICollection<Follower>> GetAllFollowing(Guid userId);
    }
}