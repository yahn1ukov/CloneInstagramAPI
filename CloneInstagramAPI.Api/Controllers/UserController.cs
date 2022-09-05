using AutoMapper;
using CloneInstagramAPI.Application.Users.Commands;
using CloneInstagramAPI.Application.Users.Common;
using CloneInstagramAPI.Application.Users.Queries;
using CloneInstagramAPI.Contracts.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CloneInstagramAPI.Api.Controllers
{
    [Authorize(Roles = "USER")]
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserController
        (
            IMediator mediator,
            IMapper mapper
        )
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserByHttpContextId()
        {
            var query = new GetUserByHttpContextIdQuery();

            var result = await _mediator.Send(query);

            return Ok(_mapper.Map<GetUserResponse>(result));
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            var query = new GetUserByUsernameQuery(username);

            var result = await _mediator.Send(query);

            return Ok(_mapper.Map<GetUserResponse>(result));
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateUserByHttpContextId(UpdateUserRequest request)
        {
            var command = _mapper.Map<UpdateUserByHttpContextIdCommand>(request);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPatch("password")]
        public async Task<IActionResult> UpdateUserPasswordByHttpContextId(UpdateUserPasswordRequest request)
        {
            var command = _mapper.Map<UpdateUserPasswordByHttpContextIdCommand>(request);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserByHttpContextId()
        {
            var command = new DeleteUserByHttpContextIdCommand();

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}