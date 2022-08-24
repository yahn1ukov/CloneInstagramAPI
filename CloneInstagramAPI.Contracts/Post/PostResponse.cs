﻿namespace CloneInstagramAPI.Contracts.Post
{
    public record PostResponse
    (
        Guid Id,
        string Content,
        string? Description,
        string? Avatar,
        string Username,
        DateTimeOffset CreatedAt
    );
}