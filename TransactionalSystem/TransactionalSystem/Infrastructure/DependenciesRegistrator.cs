using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransactionalSystem.Services.Infrastructure;

namespace TransactionalSystem.Infrastructure
{
    public static class DependenciesRegistrator
    {
        internal static void Register(IServiceCollection services, IConfiguration configuration)
        {
            SDependenciesRegistrator.Register(services);
        }
    }
}
