using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.User
{
    public class UserIsUnBannedException : CustomException
    {
        public UserIsUnBannedException()
            : base(400, "User is unbanned.") { }
    }
}