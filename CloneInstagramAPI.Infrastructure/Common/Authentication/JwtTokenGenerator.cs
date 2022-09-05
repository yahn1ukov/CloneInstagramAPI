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

        public JwtTokenGenerator
        (
            IOptions<JwtTokenSettings> jwtTokenSettings,
            IDateTimeProvider dateTimeProvider
        )
        {
            _jwtTokenSettings = jwtTokenSettings.Value;
            _dateTimeProvider = dateTimeProvider;
        }

        public string GeneratorToken(User user)
        {
            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            byte[] secretKey = Encoding.UTF8.GetBytes(_jwtTokenSettings.Secret);

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(secretKey);

            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken
            (
                issuer: _jwtTokenSettings.Issuer,
                audience: _jwtTokenSettings.Audience,
                signingCredentials: signingCredentials,
                expires: _dateTimeProvider.UtcNow.AddHours(_jwtTokenSettings.ExpiryMinutes),
                claims: claims
            );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }
    }
}