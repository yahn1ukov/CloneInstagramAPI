﻿namespace CloneInstagramAPI.Contracts.Authentication
{
    public record LoginRequest
    (
        string UserName,
        string Password
    );
}