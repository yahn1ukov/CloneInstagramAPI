﻿using CloneInstagramAPI.Application.Posts.Common;
using MediatR;

namespace CloneInstagramAPI.Application.Posts.Queries
{
    public record GetPostByIdQuery(Guid PostId) : IRequest<PostResult>;
}