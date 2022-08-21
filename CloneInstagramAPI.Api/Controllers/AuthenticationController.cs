using AutoMapper;
using CloneInstagramAPI.Application.Authentication.Commands;
using CloneInstagramAPI.Application.Authentication.Queries;
using CloneInstagramAPI.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CloneInstagramAPI.Api.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);

            var result = await _mediator.Send(query);

            return Ok(_mapper.Map<LoginResponse>(result));
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration(RegistrationRequest request)
        {
            var command = _mapper.Map<RegistrationCommand>(request);

            var result = await _mediator.Send(command);

            return Created(nameof(Registration), result);
        }
    }
}