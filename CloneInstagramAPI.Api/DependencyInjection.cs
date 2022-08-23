namespace CloneInstagramAPI.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentention(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(Program).Assembly);

            return services;
        }
    }
}