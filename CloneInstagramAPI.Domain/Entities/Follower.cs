namespace CloneInstagramAPI.Domain.Entities
{
    public class Follower
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid FollowedUserId { get; set; }
    }
}