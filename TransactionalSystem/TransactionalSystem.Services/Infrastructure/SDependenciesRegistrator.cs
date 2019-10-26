using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TransactionalSystem.DataAccess.Infrastructure;

namespace TransactionalSystem.Services.Infrastructure
{
    public static class SDependenciesRegistrator
    {
        public static void Register(IServiceCollection services)
        {
            DADependenciesRegistrator.Register(services);

            RegisterServices(services);
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<ITransactionsService, TransactionsService>();
            services.AddSingleton<IBalanceService, BalanceService>();
        }
    }
}
