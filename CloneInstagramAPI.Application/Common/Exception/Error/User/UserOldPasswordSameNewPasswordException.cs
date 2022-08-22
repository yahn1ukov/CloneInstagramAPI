using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.User
{
    public class UserOldPasswordSameNewPasswordException : CustomException
    {
        public UserOldPasswordSameNewPasswordException()
            : base(400, "Password must be different.") { }
    }
}