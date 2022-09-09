using AutoMapper;
using CloneInstagramAPI.Application.Posts.Commands;
using CloneInstagramAPI.Application.Posts.Common;
using CloneInstagramAPI.Contracts.Post;

namespace CloneInstagramAPI.Api.Common.Mapping
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<CreatePostRequest, CreatePostCommand>();
            
            CreateMap<GetAllPostsResult, GetAllPostsResponse>();
            CreateMap<GetAllPostsFollowingsResult, GetAllPostsFollowingsResponse>();
        }
    }
}