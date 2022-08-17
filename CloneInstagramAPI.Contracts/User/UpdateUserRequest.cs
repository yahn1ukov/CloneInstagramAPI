namespace CloneInstagramAPI.Contracts.User
{
    public record UpdateUserRequest
    (
        string Avatar,
        string FullName,
        string UserName,
        string WebSite,
        string Biography,
        string Email,
        string PhoneNumber,
        string Gender
    );
}