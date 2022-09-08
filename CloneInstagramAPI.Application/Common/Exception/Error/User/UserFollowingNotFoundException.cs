using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.User
{
    public class UserFollowingNotFoundException : CustomException
    {
        public UserFollowingNotFoundException()
            : base(404, "Following not found.") { }
    }
}