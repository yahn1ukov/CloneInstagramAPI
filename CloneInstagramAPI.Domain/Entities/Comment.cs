namespace CloneInstagramAPI.Domain.Entities
{
    public class Comment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public User User { get; set; } = new User();
        public Post Post { get; set; } = new Post();
        public string Text { get; set; } = string.Empty;
        public DateTimeOffset CreateAt { get; set; } = DateTimeOffset.UtcNow;
    }
}
