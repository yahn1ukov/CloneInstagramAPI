namespace CloneInstagramAPI.Domain.Entities
{
    public class Message
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Room Room { get; set; } = new Room();
        public User User { get; set; } = new User();
        public string Text { get; set; } = string.Empty;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}
