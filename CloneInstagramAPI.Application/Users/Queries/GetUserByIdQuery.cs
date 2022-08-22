﻿using CloneInstagramAPI.Application.Users.Common;
using MediatR;

namespace CloneInstagramAPI.Application.Users.Queries
{
    public record GetUserByIdQuery(Guid Id) : IRequest<ProfileResult>;
}