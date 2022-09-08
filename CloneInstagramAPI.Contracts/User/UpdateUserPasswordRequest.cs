namespace CloneInstagramAPI.Contracts.User
{
    public record UpdateUserPasswordRequest
    (
        string OldPassword,
        string NewPassword,
        string ConfirmNewPassword
    );
}