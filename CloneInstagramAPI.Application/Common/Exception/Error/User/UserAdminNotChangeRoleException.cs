using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.User
{
    public class UserAdminNotChangeRoleException : CustomException
    {
        public UserAdminNotChangeRoleException()
            : base(400, "Can't change the role to the admin.") { }
    }
}