using AutoMapper;
using CloneInstagramAPI.Application.Authentication.Commands;
using CloneInstagramAPI.Application.Authentication.Queries;
using CloneInstagramAPI.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CloneInstagramAPI.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var command = _mapper.Map<LoginQuery>(request);

            var loginResult = await _mediator.Send(command);

            return Ok(_mapper.Map<LoginResponse>(loginResult));
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationRequest request)
        {
            var command = _mapper.Map<RegistrationCommand>(request);

            var registrationResult = await _mediator.Send(command);

            return Created(nameof(Registration), _mapper.Map<LoginResponse>(registrationResult));
        }
    }
}