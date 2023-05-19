using CashFlow.Domain.Core.Interfaces.Repositorys;
using CashFlow.Domain.Core.Interfaces.Services;
using CashFlow.Domain.Models;

namespace CashFlow.Domain.Services.Services
{
    public class ServiceConsolidated : ServiceBase<Consolidated>, IServiceConsolidated
    {
        public readonly IRepositoryConsolidated _repositoryConsolidated;

        public ServiceConsolidated(IRepositoryConsolidated RepositoryConsolidated) : base(RepositoryConsolidated)
        {
            _repositoryConsolidated = RepositoryConsolidated;
        }

        public async Task<IEnumerable<Consolidated>> GetByYearAsync(int year)
        {
            return await _repositoryConsolidated.GetByYearAsync(year);
        }

        public async Task<Consolidated> GetByMonthYearAsync(int month, int year)
        {
            return await _repositoryConsolidated.GetByMonthYearAsync(month, year);
        }
    }
}
