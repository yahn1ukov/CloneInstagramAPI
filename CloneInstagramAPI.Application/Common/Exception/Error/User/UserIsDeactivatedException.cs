using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.User
{
    public class UserIsDeactivatedException : CustomException
    {
        public UserIsDeactivatedException()
            : base(400, "User is deactivated.") { }
    }
}