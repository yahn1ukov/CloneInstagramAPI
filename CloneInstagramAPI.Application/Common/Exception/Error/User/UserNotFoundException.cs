using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.User
{
    public class UserNotFoundException : CustomException
    {
        public UserNotFoundException()
            : base(404, "User not found.") { }
    }
}