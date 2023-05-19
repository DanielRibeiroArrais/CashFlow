using CashFlow.Domain.Core.Interfaces.Repositorys;
using CashFlow.Domain.Models;
using CashFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.Repository.Repositorys
{
    public class RepositoryConsolidated : RepositoryBase<Consolidated>, IRepositoryConsolidated
    {
        private readonly CashFlowDbContext _context;
        public RepositoryConsolidated(CashFlowDbContext Context) : base(Context)
        {
            _context = Context;
        }

        public async Task<IEnumerable<Consolidated>> GetByYearAsync(int year)
        {
            return await _context.Consolidated
                .Where(x => x.OperationYear.Equals(year))
                .ToListAsync();
        }

        public async Task<Consolidated?> GetByMonthYearAsync(int month, int year)
        {
            return await _context.Consolidated
                .Where(x => x.OperationMonth.Equals(month) && x.OperationYear.Equals(year))
                .FirstOrDefaultAsync();
        }
    }
}
