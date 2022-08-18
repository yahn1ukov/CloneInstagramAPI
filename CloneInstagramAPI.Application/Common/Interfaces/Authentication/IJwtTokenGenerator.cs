using CloneInstagramAPI.Domain.Entities;

namespace CloneInstagramAPI.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GeneratorToken(User user);
    }
}