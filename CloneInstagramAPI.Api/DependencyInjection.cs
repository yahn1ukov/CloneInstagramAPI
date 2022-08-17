namespace CloneInstagramAPI.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentention(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}