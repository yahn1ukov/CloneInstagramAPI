using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.User
{
    public class UserInvalidPasswordException : CustomException
    {
        public UserInvalidPasswordException()
            : base(400, "Invalid password.") { }
    }
}