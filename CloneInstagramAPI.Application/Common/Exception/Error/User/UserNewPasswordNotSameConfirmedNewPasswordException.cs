using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.User
{
    public class UserNewPasswordNotSameConfirmedNewPasswordException : CustomException
    {
        public UserNewPasswordNotSameConfirmedNewPasswordException()
            : base(400, "Confirmed password isn't like new password.") { }
    }
}