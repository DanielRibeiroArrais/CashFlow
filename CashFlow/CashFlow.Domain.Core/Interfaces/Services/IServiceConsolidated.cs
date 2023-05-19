using CashFlow.Domain.Core.Interfaces.Repositorys;
using CashFlow.Domain.Models;

namespace CashFlow.Domain.Core.Interfaces.Services
{
    public interface IServiceConsolidated : IRepositoryBase<Consolidated>
    {
        Task<IEnumerable<Consolidated>> GetByYearAsync(int year);

        Task<Consolidated> GetByMonthYearAsync(int month, int year);
    }
}
