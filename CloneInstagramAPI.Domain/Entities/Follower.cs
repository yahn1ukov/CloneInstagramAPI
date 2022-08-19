namespace CloneInstagramAPI.Domain.Entities
{
    public class Follower
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public User User { get; set; } = new User();
        public Guid FollowedUserId { get; set; }
    }
}