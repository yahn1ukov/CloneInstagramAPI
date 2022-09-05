using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using CloneInstagramAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CloneInstagramAPI.Infrastructure.Persistence
{
    public class SaveRepository : IPostActionRepository<Save>
    {
        private readonly ApplicationDbContext _context;

        public SaveRepository
        (
            ApplicationDbContext context
        )
        {
            _context = context;
        }

        public async Task<Save> Get(Guid userId, Guid postId)
        {
            return await _context.Saves.SingleAsync(s => s.UserId == userId && s.PostId == postId);
        }

        public async Task Add(Save save)
        {
            _context.Saves.Add(save);

            await _context.SaveChangesAsync();
        }

        public async Task Remove(Save save)
        {
            _context.Saves.Remove(save);

            await _context.SaveChangesAsync();
        }
    }
}