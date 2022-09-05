using AutoMapper;
using CloneInstagramAPI.Application.Users.Commands;
using CloneInstagramAPI.Application.Users.Common;
using CloneInstagramAPI.Contracts.User;

namespace CloneInstagramAPI.Api.Common.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<GetUserResult, GetUserResponse>();
            CreateMap<GetAllUsersResult, GetAllUsersResponse>();
            CreateMap<UpdateUserRequest, UpdateUserByHttpContextIdCommand>();
            CreateMap<UpdateUserPasswordRequest, UpdateUserPasswordByHttpContextIdCommand>();
        }
    }
}