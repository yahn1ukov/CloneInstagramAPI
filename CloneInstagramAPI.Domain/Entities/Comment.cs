namespace CloneInstagramAPI.Domain.Entities
{
    public class Comment 
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Message { get; set; } = string.Empty;
        public Guid? UserId { get; set; }
        public User User { get; set; }
        public Guid? PostId { get; set; }
        public Post Post { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}