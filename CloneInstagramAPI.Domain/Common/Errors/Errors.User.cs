using ErrorOr;

namespace CloneInstagramAPI.Domain.Common.Errors
{
    public static partial class Errors
    {
        public static class User
        {
            public static Error NotFound = Error.NotFound
            (
                code: "User.NotFound",
                description: "User not found."
            );

            public static Error AlreadyExists = Error.Conflict
            (
                code: "User.AlreadyExists",
                description: "User already exists."
            );

            public static Error InvalidPassword = Error.Validation
            (
                code: "User.InvalidPassword",
                description: "Invalid password."
            );
        }
    }
}