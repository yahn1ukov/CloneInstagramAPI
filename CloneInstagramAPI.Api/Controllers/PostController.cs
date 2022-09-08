using AutoMapper;
using CloneInstagramAPI.Application.Posts.Commands;
using CloneInstagramAPI.Application.Posts.Common;
using CloneInstagramAPI.Application.Posts.Queries;
using CloneInstagramAPI.Contracts.Comment;
using CloneInstagramAPI.Contracts.Post;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CloneInstagramAPI.Api.Controllers
{
    [Authorize(Roles = "USER")]
    [ApiController]
    [Route("api/posts")]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PostController
        (
            IMediator mediator,
            IMapper mapper
        )
        { 
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostRequest request)
        {
            var command = _mapper.Map<CreatePostCommand>(request);

            var result = await _mediator.Send(command);

            return Created(nameof(CreatePost), result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPosts()
        {
            var query = new GetAllPostsQuery();

            var result = await _mediator.Send(query);

            return Ok
            (
                result
                .Select(p => _mapper.Map<GetAllPostsResponse>(p))
                .ToList()
            );
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetPostById(Guid postId)
        {
            var query = new GetPostByIdQuery(postId);

            var result = await _mediator.Send(query);

            var comments = result.Comments
                            .Select(c => new GetAllCommentsResponse(c.Id, c.Message, c.Username, c.Avatar, c.CreatedAt))
                            .ToList();

            var post = new GetPostResponse
            (
                result.Id, result.Content, result.Description,
                result.Avatar, result.Username, result.CountLikes,
                result.CountSaves, result.CountComments, comments,
                result.IsLike, result.IsSave, result.CreatedAt
            );

            return Ok(post);
        }

        [HttpGet("users/{username}")]
        public async Task<IActionResult> GetAllPostsUserByUsername(string username)
        {
            var query = new GetAllPostsUserByUsernameQuery(username);

            var result = await _mediator.Send(query);

            return Ok
            (
                 result
                .Select(p => _mapper.Map<GetAllPostsResponse>(p))
                .ToList()   
            );
        }

        [HttpGet("users/{username}/likes")]
        public async Task<IActionResult> GetAllPostsLikesUserByUsername(string username)
        {
            var query = new GetAllPostsLikesUserByUsernameQuery(username);

            var result = await _mediator.Send(query);

            return Ok
            (
                 result
                .Select(p => _mapper.Map<GetAllPostsResponse>(p))
                .ToList()   
            );
        }

        [HttpGet("users/{username}/saves")]
        public async Task<IActionResult> GetAllPostsSavesUserByUsername(string username)
        {
            var query = new GetAllPostsSavesUserByUsernameQuery(username);

            var result = await _mediator.Send(query);

            return Ok
            (
                 result
                .Select(p => _mapper.Map<GetAllPostsResponse>(p))
                .ToList()   
            );
        }

        [HttpGet("users/{username}/following")]
        public async Task<IActionResult> GetAllPostsFollowingByUsername(string username)
        {
            var query = new GetAllPostsFollowingByUsernameQuery(username);

            var result = await _mediator.Send(query);

            return Ok
            (
                 result
                .Select(p => _mapper.Map<GetAllPostsFollowingResponse>(p))
                .ToList()   
            );
        }

        [HttpPatch("{postId}")]
        public async Task<IActionResult> UpdatePostById(Guid postId, UpdatePostRequest request)
        {
            var command = new UpdatePostByIdCommand(postId, request.Description);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{postId}")]
        public async Task<IActionResult> DeletePostById(Guid postId)
        {
            var command = new DeletePostByIdCommand(postId);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("{postId}/like")]
        public async Task<IActionResult> UpdatePostSetLikeById(Guid postId)
        {
            var command = new UpdatePostSetLikeByIdCommand(postId);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{postId}/unlike")]
        public async Task<IActionResult> UpdatePostUnsetLikeById(Guid postId)
        {
            var command = new UpdatePostUnsetLikeByIdCommand(postId);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("{postId}/save")]
        public async Task<IActionResult> UpdatePostSetSaveById(Guid postId)
        {
            var command = new UpdatePostSetSaveByIdCommand(postId);

            bool result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{postId}/unsave")]
        public async Task<IActionResult> UpdatePostUnsetSaveById(Guid postId)
        {
            var command = new UpdatePostUnsetSaveByIdCommand(postId);

            bool result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("{postId}/comment")]
        public async Task<IActionResult> UpdatePostAddCommentById(Guid postId, AddCommentRequest request)
        {
            var command = new UpdatePostAddCommentByIdCommand(postId, request.Message);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{commentId}/uncomment")]
        public async Task<IActionResult> UpdatePostDeleteCommentById(Guid commentId)
        {
            var command = new UpdatePostDeleteCommentByIdCommand(commentId);

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}