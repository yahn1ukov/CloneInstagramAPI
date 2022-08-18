using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CloneInstagramAPI.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentention(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Program).Assembly);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JwtSettings:Secret").Value)),
                    RequireExpirationTime = true,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true
                };
            });

            return services;
        }
    }
}