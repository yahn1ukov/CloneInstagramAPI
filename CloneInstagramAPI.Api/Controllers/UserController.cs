using AutoMapper;
using CloneInstagramAPI.Application.Users.Commands;
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

        public UserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetById()
        {
            var query = new GetCurrentUserByIdQuery();

            var result = await _mediator.Send(query);

            return Ok(_mapper.Map<ProfileResponse>(result));
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetByUserName(string username)
        {
            var query = new GetUserByUserNameQuery(username);

            var result = await _mediator.Send(query);

            return Ok(_mapper.Map<ProfileResponse>(result));
        }

        [HttpPatch]
        public async Task<IActionResult> Update(UpdateUserRequest request)
        {
            var command = _mapper.Map<UpdateUserCommand>(request);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPatch("password")]
        public async Task<IActionResult> UpdatePassword(UpdateUserPasswordRequest request)
        {
            var command = _mapper.Map<UpdateUserPasswordCommand>(request);

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            var command = new DeleteCurrentUserByIdCommand();

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}