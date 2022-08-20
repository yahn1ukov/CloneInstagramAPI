using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.User
{
    public class UserIsBannedException : CustomException
    {
        public UserIsBannedException()
            : base(400, "User is banned.") { }
    }
}