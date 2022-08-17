namespace CloneInstagramAPI.Domain.Entities
{
    public class Save
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public User User { get; set; } = new User();
        public Post Post { get; set; } = new Post();
    }
}
