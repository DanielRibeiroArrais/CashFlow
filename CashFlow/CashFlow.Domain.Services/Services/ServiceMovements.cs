using CashFlow.Domain.Core.Interfaces.Repositorys;
using CashFlow.Domain.Core.Interfaces.Services;
using CashFlow.Domain.Models;

namespace CashFlow.Domain.Services.Services
{
    public class ServiceMovements : ServiceBase<Movements>, IServiceMovements
    {
        public readonly IRepositoryMovements _repositoryMovements;

        public ServiceMovements(IRepositoryMovements RepositoryMovements) : base(RepositoryMovements)
        {
            _repositoryMovements = RepositoryMovements;
        }
    }
}
