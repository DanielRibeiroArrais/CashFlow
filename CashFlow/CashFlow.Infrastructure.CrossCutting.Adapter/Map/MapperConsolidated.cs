using CashFlow.Application.DTO.DTO;
using CashFlow.Domain.Models;
using CashFlow.Infrastructure.CrossCutting.Adapter.Interfaces;

namespace CashFlow.Infrastructure.CrossCutting.Adapter.Map
{
    public class MapperConsolidated : IMapperConsolidated
    {
        #region properties
        List<ConsolidatedDTO> consolidatedDTOs = new List<ConsolidatedDTO>();
        #endregion

        #region methods
        public Consolidated MapperToEntity(ConsolidatedDTO consolidatedDTO)
        {
            return new Consolidated(consolidatedDTO.Id, consolidatedDTO.Total, consolidatedDTO.OperationMonth, consolidatedDTO.OperationYear);
        }

        public IEnumerable<ConsolidatedDTO> MapperListConsolidateds(IEnumerable<Consolidated> consolidateds)
        {
            foreach (var item in consolidateds)
            {
                ConsolidatedDTO consolidatedDTO = new ConsolidatedDTO
                {
                    Id = item.Id,
                    Total = item.Total,
                    OperationMonth = item.OperationMonth,
                    OperationYear = item.OperationYear
                };

                consolidatedDTOs.Add(consolidatedDTO);
            }

            return consolidatedDTOs;
        }

        public ConsolidatedDTO MapperToDTO(Consolidated consolidated)
        {
            ConsolidatedDTO consolidatedDTO = new ConsolidatedDTO
            {
                Id = consolidated.Id,
                Total = consolidated.Total,
                OperationMonth = consolidated.OperationMonth,
                OperationYear = consolidated.OperationYear
            };

            return consolidatedDTO;
        }
        #endregion
    }
}
