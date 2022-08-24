using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.User
{
    public class UserIsUnbannedException : CustomException
    {
        public UserIsUnbannedException()
            : base(400, "User is unbanned.") { }
    }
}