namespace CloneInstagramAPI.Domain.Entities
{
    public class Post
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Content { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Guid? UserId { get; set; }
        public User User { get; set; }
        public List<Like> Likes { get; set; }
        public List<Save> Saves { get; set; }
        public List<Comment> Comments { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}