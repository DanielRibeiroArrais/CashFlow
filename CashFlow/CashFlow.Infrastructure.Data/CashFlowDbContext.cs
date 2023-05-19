using CashFlow.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace CashFlow.Infrastructure.Data
{
    public class CashFlowDbContext : DbContext
    {
        private readonly IServiceProvider _serviceProvider;

        public CashFlowDbContext(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public CashFlowDbContext(DbContextOptions<CashFlowDbContext> options, IServiceProvider serviceProvider) : base(options)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Consolidados movimentos
        /// </summary>
        public DbSet<Consolidated> Consolidated { get; set; }

        /// <summary>
        /// Lançamentos movimentos
        /// </summary>
        public DbSet<Movements> Movements { get; set; }
    }
}