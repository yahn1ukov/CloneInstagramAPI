namespace CloneInstagramAPI.Domain.Entities
{
    public class Room
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public User User { get; set; } = new User();
        public User PenPalUser { get; set; } = new User();
        public List<Message> Messages { get; set; } = new List<Message>();
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}
