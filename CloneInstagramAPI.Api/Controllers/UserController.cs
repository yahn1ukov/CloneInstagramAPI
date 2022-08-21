using AutoMapper;
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

        [HttpGet("{username}")]
        public async Task<IActionResult> GetByUserName(string username)
        {
            var query = new GetUserByUserNameQuery(username);

            var result = await _mediator.Send(query);

            return Ok(_mapper.Map<ProfileResponse>(result));
        }

        [HttpGet("current")]
        public async Task<IActionResult> GetById()
        {
            var query = new GetUserByIdQuery();

            var result = await _mediator.Send(query);

            return Ok(_mapper.Map<ProfileResponse>(result));
        }
    }
}