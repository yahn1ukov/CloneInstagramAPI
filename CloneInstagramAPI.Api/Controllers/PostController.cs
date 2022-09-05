﻿using System;
using AutoMapper;
using CloneInstagramAPI.Application.Posts.Commands;
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

        public PostController(IMediator mediator, IMapper mapper)
        { 
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostRequest request)
        {
            var command = _mapper.Map<CreatePostCommand>(request);

            var result = await _mediator.Send(command);

            return Created(nameof(Create), result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllPostsQuery();

            var result = await _mediator.Send(query);

            return Ok
            (
                result
                .Select(p => new AllPostsResponse(p.Id, p.Content))
                .ToList()
            );
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> Get(Guid postId)
        {
            var query = new GetPostByIdQuery(postId);

            var result = await _mediator.Send(query);

            return Ok(_mapper.Map<PostResponse>(result));
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var query = new GetAllPostsCurrentUserByIdQuery();

            var result = await _mediator.Send(query);

            return Ok
            (
                 result
                .Select(p => _mapper.Map<AllPostsResponse>(result))
                .ToList()   
            );
        }

        [HttpPatch("{postId}")]
        public async Task<IActionResult> Update(Guid postId, UpdateDescriptionRequest request)
        {
            var command = new UpdatePostDescriptionCommand(postId, request.Description);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [Authorize(Roles = "ADMIN, USER")]
        [HttpDelete("{postId}")]
        public async Task<IActionResult> Delete(Guid postId)
        {
            var command = new DeletePostByIdCommand(postId);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("{postId}/like")]
        public async Task<IActionResult> SetLike(Guid postId)
        {
            var command = new UpdatePostSetLikeCommand(postId);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{postId}/unlike")]
        public async Task<IActionResult> UnsetLike(Guid postId)
        {
            var command = new UpdatePostUnsetLikeCommand(postId);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("{postId}/save")]
        public async Task<IActionResult> SetSave(Guid postId)
        {
            var command = new UpdatePostSetSaveCommand(postId);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{postId}/unsave")]
        public async Task<IActionResult> UnsetSave(Guid postId)
        {
            var command = new UpdatePostUnsetSaveCommand(postId);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("{postId}/comment")]
        public async Task<IActionResult> AddComment(Guid postId, CreateCommentRequest request)
        {
            var command = new UpdatePostAddCommentCommand(postId, request.Message);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{postId}/uncomment")]
        public async Task<IActionResult> DeleteComment(Guid postId)
        {
            var command = new UpdatePostRemoveCommentCommand(postId);

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}