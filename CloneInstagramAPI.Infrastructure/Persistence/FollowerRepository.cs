using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using CloneInstagramAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CloneInstagramAPI.Infrastructure.Persistence
{
    public class FollowerRepository : IFollowerRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowerRepository
        (
            ApplicationDbContext context
        )
        {
            _context = context;
        }

        public async Task<ICollection<Follower>> GetAllFollowers(Guid userId)
        {
            return await _context.Followers
                .Include(f => f.User)
                .Where(f => f.FollowingUserId == userId)
                .ToListAsync();
        }

        public async Task<ICollection<Follower>> GetAllFollowing(Guid userId)
        {
            return await _context.Followers
                .Include(f => f.User)
                .Where(f => f.UserId == userId)
                .ToListAsync();
        }

        public async Task<Follower?> Get(Guid userId, Guid followingUserId)
        {
            return await _context.Followers.SingleOrDefaultAsync(f => f.UserId == userId && f.FollowingUserId == followingUserId);
        }

        public async Task Add(Follower follower)
        {
            _context.Followers.Add(follower);

            await _context.SaveChangesAsync();
        }

        public async Task Remove(Follower follower)
        {
            _context.Followers.Remove(follower);

            await _context.SaveChangesAsync();
        }

        public Task<ICollection<Follower>> GetAll(Guid entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Follower>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}