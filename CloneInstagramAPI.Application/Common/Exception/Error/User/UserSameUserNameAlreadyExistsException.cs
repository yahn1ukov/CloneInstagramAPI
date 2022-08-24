using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.User
{
    public class UserSameUsernameAlreadyExistsException : CustomException
    {
        public UserSameUsernameAlreadyExistsException()
            : base(400, "User with same username already exists.") { }
    }
}