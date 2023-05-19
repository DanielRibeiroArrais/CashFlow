using CashFlow.Domain.Core.Interfaces.Repositorys;
using CashFlow.Domain.Models;
using CashFlow.Infrastructure.Data;

namespace CashFlow.Infrastructure.Repository.Repositorys
{
    public class RepositoryMovements : RepositoryBase<Movements>, IRepositoryMovements
    {
        private readonly CashFlowDbContext _context;
        public RepositoryMovements(CashFlowDbContext Context) : base(Context)
        {
            _context = Context;
        }
    }
}
