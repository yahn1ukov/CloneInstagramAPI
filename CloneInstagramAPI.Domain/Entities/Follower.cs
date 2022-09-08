namespace CloneInstagramAPI.Domain.Entities
{
    public class Follower
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid? UserId { get; set; }
        public User User { get; set; }
        public Guid? FollowingUserId { get; set; }
        public User FollowingUser { get; set; }
    }
}