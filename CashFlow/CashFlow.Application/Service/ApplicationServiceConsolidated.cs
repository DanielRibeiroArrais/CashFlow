using CashFlow.Application.DTO.DTO;
using CashFlow.Application.Interfaces;
using CashFlow.Domain.Core.Interfaces.Services;
using CashFlow.Domain.Models;
using CashFlow.Infrastructure.CrossCutting.Adapter.Interfaces;

namespace CashFlow.Application.Service
{
    public class ApplicationServiceConsolidated : IApplicationServiceConsolidated
    {
        private readonly IServiceConsolidated _serviceConsolidated;
        private readonly IMapperConsolidated _mapperConsolidated;
        private readonly IServiceMovements _serviceMovements;

        public ApplicationServiceConsolidated(IServiceConsolidated serviceConsolidated, IMapperConsolidated mapperConsolidated, IServiceMovements serviceMovements)
        {
            _serviceConsolidated = serviceConsolidated;
            _mapperConsolidated = mapperConsolidated;
            _serviceMovements = serviceMovements;
        }

        public async Task<IEnumerable<ConsolidatedDTO>> GetAllAsync()
        {
            return _mapperConsolidated.MapperListConsolidateds(await _serviceConsolidated.GetAllAsync());
        }

        public async Task<IEnumerable<ConsolidatedDTO>> GetByYearAsync(int year)
        {
            return _mapperConsolidated.MapperListConsolidateds(await _serviceConsolidated.GetByYearAsync(year));
        }

        public async Task<ConsolidatedDTO> GetByMonthYearAsync(int month, int year)
        {
            return _mapperConsolidated.MapperToDTO(await _serviceConsolidated.GetByMonthYearAsync(month, year));
        }

        public async Task CashFlowConsolidateAsync()
        {
            var existingMovements = await _serviceMovements.GetAllAsync();
            var existingConsolidateds = await _serviceConsolidated.GetAllAsync();

            var datesConsolidates = existingMovements
                .Where(m => m.ModificationDate >= (existingConsolidateds.Count() == 0 ? DateTime.MinValue : existingConsolidateds.Max(c => c.ModificationDate)))
                .OrderBy(m => m.OperationDate)
                .Select(p => new { p.OperationDate.Year, p.OperationDate.Month })
                .Distinct()
                .ToList()
                .Select(x => new DateTime(x.Year, x.Month, 1));

            List<Consolidated> newConsolidateds = new List<Consolidated>();
            Consolidated? newConsolidated = null;

            foreach (var item in datesConsolidates)
            {
                newConsolidated = existingMovements
                    .Where(x => x.OperationDate.Year.Equals(item.Year) && x.OperationDate.Month.Equals(item.Month))
                    .GroupBy(e => new { e.OperationDate.Year, e.OperationDate.Month })
                    .Select(s => new Consolidated(
                        0,
                        s.Sum(m => m.MovementType == DTO.Enum.EnumMovementType.Debit ? (m.Value * -1) : m.Value),
                        s.First().OperationDate.Month,
                        s.First().OperationDate.Year
                        ))
                    .FirstOrDefault();


                newConsolidateds.Add(newConsolidated);
            }

            foreach (var newConsolidatedItem in newConsolidateds)
            {
                var existingConsolidated = existingConsolidateds.Where(x => x.OperationYear == newConsolidatedItem.OperationYear && x.OperationMonth == newConsolidatedItem.OperationMonth).FirstOrDefault();

                if (existingConsolidated != null)
                {
                    existingConsolidated.Total = newConsolidatedItem.Total;
                    existingConsolidated.ModificationDate = DateTime.Now;

                    await _serviceConsolidated.UpdateAsync(existingConsolidated);
                }
                else
                {
                    newConsolidatedItem.ModificationDate = DateTime.Now;
                    await _serviceConsolidated.CreateAsync(newConsolidatedItem);
                }
            }
        }
    }
}
