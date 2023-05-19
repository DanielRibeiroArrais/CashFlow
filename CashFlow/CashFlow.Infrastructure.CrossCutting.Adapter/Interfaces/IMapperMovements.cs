using CashFlow.Application.DTO.DTO;
using CashFlow.Domain.Models;

namespace CashFlow.Infrastructure.CrossCutting.Adapter.Interfaces
{
    public interface IMapperMovements
    {
        #region Mappers

        Movements MapperToEntity(MovementsDTO movementsDTO);

        IEnumerable<MovementsDTO> MapperListMovements(IEnumerable<Movements> movements);

        MovementsDTO MapperToDTO(Movements movements);

        #endregion
    }
}
