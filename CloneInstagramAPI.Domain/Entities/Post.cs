namespace CloneInstagramAPI.Domain.Entities
{
    public class Post
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Content { get; set; } = string.Empty;
        public string? Description { get; set; }
        public User User { get; set; } = new User();
        public List<Like> Likes { get; set; } = new List<Like>();
        public List<Save> Saves { get; set; } = new List<Save>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}
