using Domain.Interfaces.Cliente;
using Microsoft.Extensions.DependencyInjection;
using Repository.Cliente;

namespace Bootstrap
{
    internal static class RepositorySetup
    {
        internal static void AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IClienteRepository, ClienteRepository>();
        }
    }
}