using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.User
{
    public class UserAdminNotChangeRoleException : CustomException
    {
        public UserAdminNotChangeRoleException()
            : base(400, "Cannot change the role of the admin.") { }
    }
}