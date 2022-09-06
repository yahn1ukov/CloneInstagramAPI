using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.User
{
    public class UserAdminCannotBeBannedException : CustomException
    {
        public UserAdminCannotBeBannedException()
            : base(400, "Admin cannot be banned.") { }
    }
}