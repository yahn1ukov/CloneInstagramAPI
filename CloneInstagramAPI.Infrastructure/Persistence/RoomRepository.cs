using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using CloneInstagramAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CloneInstagramAPI.Infrastructure.Persistence
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomRepository
        (
            ApplicationDbContext context
        )
        {
            _context = context;
        }

        public async Task Create(Room room)
        {
            _context.Rooms.Add(room);

            await _context.SaveChangesAsync();
        }

        public async Task<Room?> GetById(Guid roomId)
        {
            return await _context.Rooms.SingleOrDefaultAsync(r => r.Id == roomId);
        }

        public async Task<Room?> GetById(Guid userHttpContextId, Guid userId)
        {
            return await _context.Rooms.SingleOrDefaultAsync(r => r.UserId == userHttpContextId && r.PenPalUserId == userId);
        }

        public async Task<ICollection<Room>> GetAll()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<ICollection<Room>> GetAllById(Guid userId)
        {
            return await _context.Rooms
                .Include(r => r.PenPalUser)
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }

        public async Task Update(Room room)
        {
            _context.Rooms.Update(room);

            await _context.SaveChangesAsync();
        }

         public async Task Delete(Room room)
        {
            _context.Rooms.Remove(room);

            await _context.SaveChangesAsync();
        }
    }
}