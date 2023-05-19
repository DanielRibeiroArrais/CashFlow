using CashFlow.Application.DTO.DTO;

namespace CashFlow.Application.Interfaces
{
    public interface IApplicationServiceMovements
    {
        Task CreateAsync(MovementsDTO movementsDTO);


        Task<MovementsDTO> GetByIdAsync(int id);
        Task<IEnumerable<MovementsDTO>> GetAllAsync();


        Task UpdateAsync(MovementsDTO movementsDTO);

        Task DeleteAsync(int id);
    }
}
