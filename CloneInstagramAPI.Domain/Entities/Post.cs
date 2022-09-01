namespace CloneInstagramAPI.Domain.Entities
{
    public class Post
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Content { get; set; } = string.Empty;
        public string? Description { get; set; }
        public User User { get; set; } = new User();
        public List<Guid> Likes = new List<Guid>();
        public List<Guid> Saves = new List<Guid>();
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}