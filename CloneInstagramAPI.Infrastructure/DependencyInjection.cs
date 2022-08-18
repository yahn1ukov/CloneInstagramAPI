using CloneInstagramAPI.Application.Common.Interfaces.Authentication;
using CloneInstagramAPI.Application.Common.Interfaces.Services;
using CloneInstagramAPI.Application.Persistence;
using CloneInstagramAPI.Infrastructure.Common.Authentication;
using CloneInstagramAPI.Infrastructure.Data;
using CloneInstagramAPI.Infrastructure.Persistence;
using CloneInstagramAPI.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace CloneInstagramAPI.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ConnectionStrings:DefaultConnection")));
            services.Configure<JwtTokenSettings>(configuration.GetSection("JwtSettings"));


            services.AddScoped<IJwtTokenGenerator,  JwtTokenGenerator>();
            services.AddScoped<IPasswordHashGenerator, PasswordHashGenerator>();
            services.AddScoped<IDateTimeProvider, DateTimeProvider>();
            

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}