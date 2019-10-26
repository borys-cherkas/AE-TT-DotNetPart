using System.Threading.Tasks;

namespace TransactionalSystem.Services
{
    public interface IBalanceService
    {
        Task<decimal> GetCurrentAccountBalanceAsync();
    }
}
