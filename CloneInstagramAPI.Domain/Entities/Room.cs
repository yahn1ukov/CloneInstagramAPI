namespace CloneInstagramAPI.Domain.Entities
{
    public class Room
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? UserId { get; set; }
        public User User { get; set; }
        public Guid? PenPalUserId { get; set; }
        public User PenPalUser { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}