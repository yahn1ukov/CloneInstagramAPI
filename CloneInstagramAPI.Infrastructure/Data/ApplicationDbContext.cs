using CloneInstagramAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CloneInstagramAPI.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>()
                .HasOne<User>(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Like>()
                .HasOne<User>(l => l.User)
                .WithMany(u => u.Likes)
                .HasForeignKey(l => l.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Like>()
                .HasOne<Post>(l => l.Post)
                .WithMany(p => p.Likes)
                .HasForeignKey(l => l.PostId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Save>()
                .HasOne<User>(s => s.User)
                .WithMany(u => u.Saves)
                .HasForeignKey(s => s.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Save>()
                .HasOne<Post>(s => s.Post)
                .WithMany(p => p.Saves)
                .HasForeignKey(s => s.PostId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Comment>()
                .HasOne<User>(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Comment>()
                .HasOne<Post>(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Follower>()
                .HasOne<User>(f => f.User)
                .WithMany(u => u.Followers)
                .HasForeignKey(f => f.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Save> Saves { get; set;}
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Follower> Followers { get; set; }
    }
}