using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using CloneInstagramAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CloneInstagramAPI.Infrastructure.Persistence
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageRepository
        (
            ApplicationDbContext context
        )
        {
            _context = context;
        }

        public async Task Add(Message message)
        {
            _context.Messages.Add(message);

            await _context.SaveChangesAsync();
        }

        public async Task<Message?> GetById(Guid messageId)
        {
            return await _context.Messages.SingleOrDefaultAsync(m => m.Id == messageId);
        }

        public async Task<Message?> GetById(Guid userId, Guid roomId)
        {
            return await _context.Messages.SingleOrDefaultAsync(m => m.UserId == userId && m.RoomId == roomId);
        }

        public async Task<ICollection<Message>> GetAllById(Guid roomId)
        {
            return await _context.Messages
                .Include(u => u.User)
                .Where(m => m.RoomId == roomId)
                .ToListAsync();
        }

         public async Task Change(Message message)
        {
            _context.Messages.Update(message);

            await _context.SaveChangesAsync();
        }
        
        public async Task Remove(Message message)
        {
            _context.Messages.Remove(message);

            await _context.SaveChangesAsync();
        }
    }
}