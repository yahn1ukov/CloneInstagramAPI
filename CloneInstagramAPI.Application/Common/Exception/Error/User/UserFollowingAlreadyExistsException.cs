using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.User
{
    public class UserFollowingAlreadyExistsException : CustomException
    {
        public UserFollowingAlreadyExistsException()
            : base(400, "Following already exists.") { }
    }
}