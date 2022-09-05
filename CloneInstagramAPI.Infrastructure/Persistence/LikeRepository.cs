using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using CloneInstagramAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CloneInstagramAPI.Infrastructure.Persistence
{
    public class LikeRepository : IPostActionRepository<Like>
    {
        private readonly ApplicationDbContext _context;

        public LikeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Like> Get(Guid userId, Guid postId)
        {
            return await _context.Likes.SingleAsync(l => l.UserId == userId && l.PostId == postId);
        }

        public async Task Add(Like like)
        {
            _context.Likes.Add(like);

            await _context.SaveChangesAsync();
        }

        public async Task Remove(Like like)
        {
            _context.Likes.Remove(like);

            await _context.SaveChangesAsync();
        }
    }
}