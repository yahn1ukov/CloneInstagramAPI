﻿using MediatR;

namespace CloneInstagramAPI.Application.Users.Commands
{
    public record UpdateCurrentUserCommand
    (
        string? Avavtar,
        string FullName,
        string Username,
        string? WebSite,
        string? Biography,
        string Email,
        string? PhoneNumber,
        int? Gender
    ) : IRequest<bool>;
}