using System.ComponentModel.DataAnnotations;

namespace CloneInstagramAPI.Contracts.User
{
    public record ChangePasswordRequest
    (
        string OldPassword,
        string NewPassword,
        string ConfirmedNewPassword
    );
}