using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Domain.Entities;
using CloneInstagramAPI.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CloneInstagramAPI.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private Guid GetUserId()
            => Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "");

        public async Task<bool> FindByEmail(string email)
        {
            if (await _context.Users.AnyAsync(u => u.Email.ToLower().Equals(email.ToLower())))
            {
                return true;
            }
            return false;
        }

        public async Task Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetById()
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Id == GetUserId());
        }

        public async Task<User?> GetByUserName(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.UserName.ToLower().Equals(username.ToLower()));
;        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.Reverse().ToListAsync();
        }

        public async Task Delete(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}