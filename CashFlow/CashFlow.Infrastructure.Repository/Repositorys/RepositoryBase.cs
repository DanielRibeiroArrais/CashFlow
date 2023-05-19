using CashFlow.Domain.Core.Interfaces.Repositorys;
using CashFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.Repository.Repositorys
{
    public abstract class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly CashFlowDbContext _context;

        public RepositoryBase(CashFlowDbContext Context)
        {
            _context = Context;
        }

        public virtual async Task CreateAsync(TEntity obj)
        {
            try
            {
                await _context.Set<TEntity>().AddAsync(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task UpdateAsync(TEntity obj)
        {
            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual async Task DeleteAsync(TEntity obj)
        {
            try
            {
                _context.Set<TEntity>().Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }
    }
}
