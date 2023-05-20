namespace CashFlow.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity obj);

        Task<TEntity> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> UpdateAsync(TEntity obj);

        Task DeleteAsync(TEntity obj);

        void Dispose();
    }
}
