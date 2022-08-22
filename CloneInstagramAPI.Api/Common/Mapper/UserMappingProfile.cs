﻿using AutoMapper;
using CloneInstagramAPI.Application.Users.Commands;
using CloneInstagramAPI.Application.Users.Common;
using CloneInstagramAPI.Contracts.User;

namespace CloneInstagramAPI.Api.Common.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<ProfileResult, ProfileResponse>();
            CreateMap<AllUsersResult, AllUsersResponse>();
            CreateMap<UpdateUserRequest, UpdateUserCommand>();
            CreateMap<UpdateUserPasswordRequest, UpdateUserPasswordCommand>();
        }
    }
}