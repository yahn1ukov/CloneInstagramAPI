using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.User
{
    public class UserAlreadyExistsException : CustomException
    {
        public UserAlreadyExistsException()
            : base(400, "User already exists.") { }
    }
}