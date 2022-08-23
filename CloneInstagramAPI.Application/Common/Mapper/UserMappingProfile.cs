using AutoMapper;
using CloneInstagramAPI.Application.Users.Commands;
using CloneInstagramAPI.Application.Users.Common;
using CloneInstagramAPI.Domain.Entities;

namespace CloneInstagramAPI.Application.Common.Mapper
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UpdateCurrentUserCommand, User>();
            CreateMap<User, ProfileResult>();
            CreateMap<User, AllUsersResult>();
        }
    }
}