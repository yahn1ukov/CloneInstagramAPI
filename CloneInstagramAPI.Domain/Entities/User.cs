using CloneInstagramAPI.Domain.Enums;

namespace CloneInstagramAPI.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public UserRole Role { get; set; } = UserRole.USER;
        public string? Avatar { get; set; }
        public string? WebSite { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Biography { get; set; }
        public UserGender Gender { get; set; } = UserGender.MALE;
        public bool IsBanned { get; set; } = false;
        public bool IsDeactived { get; set; } = false;
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Like> Likes { get; set; } = new List<Like>();
        public List<Save> Saves { get; set; } = new List<Save>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<Follower> Followers { get; set; } = new List<Follower>();
        public List<Room> Rooms { get; set; } = new List<Room>();
        public List<Message> Messages { get; set; } = new List<Message>();
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}