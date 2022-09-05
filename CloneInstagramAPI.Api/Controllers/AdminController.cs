using AutoMapper;
using CloneInstagramAPI.Application.Posts.Queries;
using CloneInstagramAPI.Application.Users.Commands;
using CloneInstagramAPI.Application.Users.Queries;
using CloneInstagramAPI.Contracts.Post;
using CloneInstagramAPI.Contracts.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CloneInstagramAPI.Api.Controllers
{
    [Authorize(Roles = "ADMIN")]
    [ApiController]
    [Route("api/admins")]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AdminController
        (
            IMediator mediator,
            IMapper mapper
        )
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var query = new GetAllUsersQuery();

            var result = await _mediator.Send(query);

            return Ok
            (
                result
                .Select(u => _mapper.Map<GetAllUsersResponse>(u))
                .ToList()
            );
        }

        [HttpGet("posts")]
        public async Task<IActionResult> GetAllPostsWithoutUsers()
        {
            var query = new GetAllPostsWithoutUsersQuery();

            var result = await _mediator.Send(query);

            return Ok
            (
                result
                .Select(p => _mapper.Map<GetAllPostsResponse>(p))
                .ToList()
            );
        }

        [HttpGet("users/{userId}")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            var query = new GetUserByIdQuery(userId);

            var result = await _mediator.Send(query);

            return Ok(_mapper.Map<GetUserResponse>(result));
        }

        [HttpPatch("users/{userId}")]
        public async Task<IActionResult> UpdateUserRoleById(Guid userId, UpdateUserRoleRequest request)
        {
            var command = new UpdateUserRoleByIdCommand(userId, request.NewRole);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPatch("users/{userId}/ban")]
        public async Task<IActionResult> BanUserById(Guid userId)
        { 
            var command = new BanUserByIdCommand(userId);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPatch("users/{userId}/unban")]
        public async Task<IActionResult> UnbanUserById(Guid userId)
        {
            var command = new UnbanUserByIdCommand(userId);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("users/{userId}")]
        public async Task<IActionResult> DeleteUserById(Guid userId)
        {
            var command = new DeleteUserByIdCommand(userId);

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}