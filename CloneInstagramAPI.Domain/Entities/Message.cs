namespace CloneInstagramAPI.Domain.Entities
{
    public class Message
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Text { get; set; } = string.Empty;
        public Guid? UserId { get; set; }
        public User User { get; set; }
        public Guid? RoomId { get; set; }
        public Room Room { get; set; }
        public bool IsEdited { get; set; } = false;
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}