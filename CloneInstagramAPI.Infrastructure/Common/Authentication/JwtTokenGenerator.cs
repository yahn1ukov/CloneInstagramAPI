using CloneInstagramAPI.Application.Common.Interfaces.Authentication;
using CloneInstagramAPI.Application.Common.Interfaces.Services;
using CloneInstagramAPI.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CloneInstagramAPI.Infrastructure.Common.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtTokenSettings _jwtTokenSettings;
        private readonly IDateTimeProvider _dateTimeProvider;

        public JwtTokenGenerator(IOptions<JwtTokenSettings> jwtTokenSettings, IDateTimeProvider dateTimeProvider)
        {
            _jwtTokenSettings = jwtTokenSettings.Value;
            _dateTimeProvider = dateTimeProvider;
        }

        public string GeneratorToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var secretKey = Encoding.UTF8.GetBytes(_jwtTokenSettings.Secret);

            var symmetricSecurityKey = new SymmetricSecurityKey(secretKey);

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: _jwtTokenSettings.Issuer,
                audience: _jwtTokenSettings.Audience,
                signingCredentials: signingCredentials,
                expires: _dateTimeProvider.UtcNow.AddHours(_jwtTokenSettings.ExpiryMinutes),
                claims: claims
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}