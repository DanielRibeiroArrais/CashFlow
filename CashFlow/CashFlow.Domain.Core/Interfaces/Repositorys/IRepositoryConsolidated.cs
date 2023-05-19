using CashFlow.Domain.Models;

namespace CashFlow.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryConsolidated : IRepositoryBase<Consolidated>
    {
        Task<IEnumerable<Consolidated>> GetByYearAsync(int year);

        Task<Consolidated> GetByMonthYearAsync(int month, int year);
    }
}
