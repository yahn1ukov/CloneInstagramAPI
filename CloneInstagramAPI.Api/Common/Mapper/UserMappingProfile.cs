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
            CreateMap<UpdateUserPasswordRequest, UpdateUserPasswordByHttpContextIdCommand>();
            CreateMap<UpdateUserRequest, UpdateUserByHttpContextIdCommand>();
            
            CreateMap<GetUserResult, GetUserResponse>();
            CreateMap<GetAllUsersResult, GetAllUsersResponse>();
            CreateMap<GetUserForNavbarResult, GetUserForNavbarResponse>();
        }
    }
}