using CashFlow.Application.DTO.DTO;
using CashFlow.Domain.Models;

namespace CashFlow.Infrastructure.CrossCutting.Adapter.Interfaces
{
    public interface IMapperConsolidated
    {
        #region Mappers

        Consolidated MapperToEntity(ConsolidatedDTO consolidatedDTO);

        IEnumerable<ConsolidatedDTO> MapperListConsolidateds(IEnumerable<Consolidated> consolidateds);

        ConsolidatedDTO MapperToDTO(Consolidated consolidated);

        #endregion
    }
}
