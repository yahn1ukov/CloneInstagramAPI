﻿namespace CloneInstagramAPI.Application.Users.Common
{
    public record GetUserResult
    (
        Guid Id,
        string Email,
        string FullName,
        string Username,
        string? Avatar,
        string? WebSite,
        string? PhoneNumber,
        string? Biography
    );
}