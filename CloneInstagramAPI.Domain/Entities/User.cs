using CloneInstagramAPI.Domain.Enums;

namespace CloneInstagramAPI.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public UserRole Role { get; set; } = UserRole.USER;
        public string? Avatar { get; set; }
        public string? WebSite { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Biography { get; set; }
        public UserGender? Gender { get; set; }
        public bool IsBanned { get; set; } = false;
        public bool IsDeactivated { get; set; } = false;
        public ICollection<Post> Posts { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Save> Saves { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Follower> Followers { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Message> Messages { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}