using CloneInstagramAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CloneInstagramAPI.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Follower> Followers { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}