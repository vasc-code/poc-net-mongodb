using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Bootstrap
{
    public static class Setup
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddSwagger();
            services.AddInfrastructure();
            services.AddRepository();
            services.AddApplication();
        }

        public static void UseSwaggerPOC(this IApplicationBuilder builder)
        {
            builder.ConfigureSwagger();
        }
    }
}