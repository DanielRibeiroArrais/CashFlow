namespace CashFlow.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity obj);

        Task<TEntity> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task UpdateAsync(TEntity obj);

        Task DeleteAsync(TEntity obj);

        void Dispose();
    }
}
