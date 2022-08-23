using CloneInstagramAPI.Application.Common.Exception.Base;

namespace CloneInstagramAPI.Application.Common.Exception.Error.User
{
    public class UserGenderNotFoundException : CustomException
    {
        public UserGenderNotFoundException()
            : base(404, "Gender not found.") { }
    }
}