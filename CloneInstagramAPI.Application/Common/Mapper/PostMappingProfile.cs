using AutoMapper;
using CloneInstagramAPI.Application.Posts.Commands;
using CloneInstagramAPI.Application.Posts.Common;
using CloneInstagramAPI.Domain.Entities;

namespace CloneInstagramAPI.Application.Common.Mapper
{
    public class PostMappingProfile : Profile
    {
        public PostMappingProfile()
        {
            CreateMap<CreatePostCommand, Post>();
            CreateMap<Post, GetAllPostsResult>();
            CreateMap<UpdatePostAddCommentByIdCommand, Comment>();
        }
    }
}