using System.ComponentModel.DataAnnotations;

namespace CloneInstagramAPI.Contracts.User
{
    public record UpdateUserPasswordRequest
    (
        string OldPassword,
        string NewPassword,
        string ConfirmedNewPassword
    );
}