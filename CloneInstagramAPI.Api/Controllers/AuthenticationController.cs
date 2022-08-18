using AutoMapper;
using CloneInstagramAPI.Application.Authentication.Commands;
using CloneInstagramAPI.Application.Authentication.Common;
using CloneInstagramAPI.Application.Authentication.Queries;
using CloneInstagramAPI.Contracts.Authentication;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CloneInstagramAPI.Api.Controllers
{
    [Route("/[controller]/[action]")]
    public class AuthenticationController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationRequest request)
        {
            var command = _mapper.Map<RegistrationCommand>(request);

            ErrorOr<AuthenticationResult> registrationResult = await _mediator.Send(command);

            return registrationResult.Match
            (
                authenticationResult => Created(nameof(Registration), null),
                errors => Problem(errors)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var command = _mapper.Map<LoginQuery>(request);

            ErrorOr<AuthenticationResult> loginResult = await _mediator.Send(command);

            return loginResult.Match
            (
                authenticationResult => Ok(_mapper.Map<LoginResponse>(authenticationResult)),
                errors => Problem(errors)
            );
        }
    }
}