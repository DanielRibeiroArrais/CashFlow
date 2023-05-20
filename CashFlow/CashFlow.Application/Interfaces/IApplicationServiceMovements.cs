using CashFlow.Application.DTO.DTO;

namespace CashFlow.Application.Interfaces
{
    public interface IApplicationServiceMovements
    {
        Task<MovementsDTO> CreateAsync(MovementsDTO movementsDTO);


        Task<MovementsDTO> GetByIdAsync(int id);
        Task<IEnumerable<MovementsDTO>> GetAllAsync();


        Task<MovementsDTO> UpdateAsync(MovementsDTO movementsDTO);

        Task DeleteAsync(int id);
    }
}
