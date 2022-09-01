using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using CloneInstagramAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CloneInstagramAPI.Infrastructure.Persistence
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(Post post)
        {
            _context.Posts.Add(post);

            await _context.SaveChangesAsync();
        }

        public async Task<Post?> GetById(Guid id)
        {
            return await _context.Posts.Include(u => u.User).SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Post>> GetAll()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task<IEnumerable<Post>> GetAllUsersById(Guid id)
        {
            return await _context.Posts
                .Include(u => u.User)
                .Where(p => p.User.Id == id)
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