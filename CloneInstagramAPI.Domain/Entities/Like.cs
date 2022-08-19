namespace CloneInstagramAPI.Domain.Entities
{
    public class Like
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public User User { get; set; } = new User();
        public Guid PostId { get; set; }
        public Post Post { get; set; } = new Post();
    }
}
