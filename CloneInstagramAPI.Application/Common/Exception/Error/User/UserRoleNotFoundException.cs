using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.User
{
    public class UserRoleNotFoundException : CustomException
    {
        public UserRoleNotFoundException()
            : base(404, "Role not found.") { }
    }
}