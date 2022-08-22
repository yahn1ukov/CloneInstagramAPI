using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.User
{
    public class UserSameEmailAlreadyExistsException : CustomException
    {
        public UserSameEmailAlreadyExistsException()
            : base(400, "User with same email already exists.") { }
    }
}