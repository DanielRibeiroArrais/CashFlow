using CashFlow.Application.DTO.DTO;

namespace CashFlow.Application.Interfaces
{
    public interface IApplicationServiceConsolidated
    {
        Task<IEnumerable<ConsolidatedDTO>> GetAllAsync();
        Task<IEnumerable<ConsolidatedDTO>> GetByYearAsync(int year);
        Task<ConsolidatedDTO> GetByMonthYearAsync(int month, int year);

        Task CashFlowConsolidateAsync();
    }
}