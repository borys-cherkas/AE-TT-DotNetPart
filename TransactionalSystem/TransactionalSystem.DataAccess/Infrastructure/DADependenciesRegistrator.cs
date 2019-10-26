using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TransactionalSystem.DataAccess.Repositories;

namespace TransactionalSystem.DataAccess.Infrastructure
{
    public static class DADependenciesRegistrator
    {
        public static void Register(IServiceCollection services)
        {
            RegisterRepositories(services);
            RegisterDbContext(services);
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddSingleton<ITransactionsRepository, TransactionsRepository>();
        }

        private static void RegisterDbContext(IServiceCollection services)
        {
            services.AddDbContext<TransactionsDbContext>(options => 
                options.UseInMemoryDatabase("TransactionsDatabase"), ServiceLifetime.Singleton);
        }
    }
}
