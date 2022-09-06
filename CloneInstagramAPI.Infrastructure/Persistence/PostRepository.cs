using System.Linq;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using CloneInstagramAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CloneInstagramAPI.Infrastructure.Persistence
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository
        (
            ApplicationDbContext context
        )
        {
            _context = context;
        }

        public async Task Create(Post post)
        {
            _context.Posts.Add(post);

            await _context.SaveChangesAsync();
        }

        public async Task<Post?> GetById(Guid postId)
        {
            return await _context.Posts
                .Include(u => u.User)
                .Include(l => l.Likes)
                .Include(s => s.Saves)
                .Include(c => c.Comments)
                .SingleOrDefaultAsync(p => p.Id == postId);
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            return await _context.Posts
                .Where(p => p.UserId != null)
                .ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetAllWithoutUsers()
        {
            return await _context.Posts
                .Where(p => p.UserId == null)
                .ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetAllUserById(Guid userId)
        {
            return await _context.Posts
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetAllLikesUserById(Guid userId)
        {
            return await _context.Posts
                .Where(p => p.Likes.Any(l => l.UserId == userId))
                .ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetAllSavesUserById(Guid userId)
        {
            return await _context.Posts
                .Where(p => p.Saves.Any(s => s.UserId == userId))
                .ToListAsync();
        }

        public async Task Update(Post post)
        {
            _context.Posts.Update(post);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Post post)
        {
            _context.Posts.Remove(post);

            await _context.SaveChangesAsync();
        }
    }
}