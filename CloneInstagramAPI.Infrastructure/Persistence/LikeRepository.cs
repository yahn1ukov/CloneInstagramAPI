using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using CloneInstagramAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CloneInstagramAPI.Infrastructure.Persistence
{
    public class LikeRepository : IActionRepository<Like>
    {
        private readonly ApplicationDbContext _context;

        public LikeRepository
        (
            ApplicationDbContext context
        )
        {
            _context = context;
        }

        public async Task<Like?> Get(Guid userId, Guid postId)
        {
            return await _context.Likes.SingleOrDefaultAsync(l => l.UserId == userId && l.PostId == postId);
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

        public async Task<ICollection<Like>> GetAll()
        {
            return await _context.Likes.ToListAsync();
        }
    }
}