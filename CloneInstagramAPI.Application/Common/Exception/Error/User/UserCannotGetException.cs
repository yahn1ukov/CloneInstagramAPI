using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.User
{
    public class UserCannotGetException : CustomException
    {
        public UserCannotGetException()
            : base(400, "Cannot get user.") { }
    }
}