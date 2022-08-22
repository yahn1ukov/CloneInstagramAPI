using AutoMapper;
using CloneInstagramAPI.Application.Users.Commands;
using CloneInstagramAPI.Application.Users.Queries;
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

        public AdminController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllUsersQuery();

            var result = await _mediator.Send(query);

            return Ok
            (
                result
                .Select(u => _mapper.Map<AllUsersResponse>(u))
                .ToList()
            );
        }

        [HttpGet("users/{userId}")]
        public async Task<IActionResult> GetByUserName(Guid userId)
        {
            var query = new GetUserByIdQuery(userId);

            var result = await _mediator.Send(query);

            return Ok(_mapper.Map<ProfileResponse>(result));
        }

        [HttpPatch("users/{userId}")]
        public async Task<IActionResult> UpdateRole(Guid userId, UpdateUserRoleRequest request)
        {
            var command = new UpdateUserRoleCommand(userId, request.NewRole);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("users/{userId}")]
        public async Task<IActionResult> Delete(Guid userId)
        {
            var command = new DeleteUserByIdCommand(userId);

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}