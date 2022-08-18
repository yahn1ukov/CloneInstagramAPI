using CloneInstagramAPI.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace CloneInstagramAPI.Application.Authentication.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            
        }
    }
}