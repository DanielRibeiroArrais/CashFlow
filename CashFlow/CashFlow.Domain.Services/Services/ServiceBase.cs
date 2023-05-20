using CashFlow.Domain.Core.Interfaces.Repositorys;
using CashFlow.Domain.Core.Interfaces.Services;

namespace CashFlow.Domain.Services.Services
{
    public abstract class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> Repository)
        {
            _repository = Repository;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity obj)
        {
            return await _repository.CreateAsync(obj);
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity obj)
        {
            return await _repository.UpdateAsync(obj);
        }

        public virtual async Task DeleteAsync(TEntity obj)
        {
            await _repository.DeleteAsync(obj);
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
        }
    }
}
