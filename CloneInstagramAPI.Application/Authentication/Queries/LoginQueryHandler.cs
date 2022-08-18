using CloneInstagramAPI.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace CloneInstagramAPI.Application.Authentication.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            
        }
    }
}