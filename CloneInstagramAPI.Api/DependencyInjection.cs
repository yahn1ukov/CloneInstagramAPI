namespace CloneInstagramAPI.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentention(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Program).Assembly);

            return services;
        }
    }
}