using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using CloneInstagramAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CloneInstagramAPI.Infrastructure.Persistence
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository
        (
            ApplicationDbContext context
        )
        {
            _context = context;
        }

        public async Task Add(Comment comment)
        {
            _context.Comments.Add(comment);

            await _context.SaveChangesAsync();    
        }

        public async Task<Comment?> GetById(Guid commentId)
        {
            return await _context.Comments.SingleOrDefaultAsync(c => c.Id == commentId);
        }

        public async Task<Comment?> GetById(Guid userId, Guid postId)
        {
            return await _context.Comments.SingleOrDefaultAsync(c => c.UserId == userId && c.PostId == postId);
        }

        public async Task<ICollection<Comment>> GetAllById(Guid postId)
        {
            return await _context.Comments
                .Include(c => c.User)
                .Where(c => c.PostId == postId)
                .ToListAsync();
        }

        public async Task Remove(Comment comment)
        {
            _context.Comments.Remove(comment);

            await _context.SaveChangesAsync();
        }
    }
}