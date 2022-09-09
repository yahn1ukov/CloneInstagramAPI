using CloneInstagramAPI.Domain.Entities;

namespace CloneInstagramAPI.Application.Persistence
{
    public interface IFollowerRepository : IActionRepository<Follower>
    {
        public Task<ICollection<Follower>> GetAllFollowersById(Guid userId);
        public Task<ICollection<Follower>> GetAllFollowingsById(Guid userId);
    }
}