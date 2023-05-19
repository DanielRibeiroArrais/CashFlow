using CashFlow.Application.DTO.DTO;
using CashFlow.Domain.Models;
using CashFlow.Infrastructure.CrossCutting.Adapter.Interfaces;

namespace CashFlow.Infrastructure.CrossCutting.Adapter.Map
{
    public class MapperMovements : IMapperMovements
    {
        #region properties
        List<MovementsDTO> movementsDTOs = new List<MovementsDTO>();
        #endregion

        #region methods
        public Movements MapperToEntity(MovementsDTO movementsDTO)
        {
            return new Movements(movementsDTO.Id, movementsDTO.MovementType, movementsDTO.Description, movementsDTO.Observation, movementsDTO.Value, movementsDTO.OperationDate);
        }

        public IEnumerable<MovementsDTO> MapperListMovements(IEnumerable<Movements> movements)
        {
            foreach (var item in movements)
            {
                MovementsDTO movementsDTO = new MovementsDTO
                {
                    Id = item.Id,
                    MovementType = item.MovementType,
                    Description = item.Description,
                    Observation = item.Observation,
                    Value = item.Value,
                    OperationDate = item.OperationDate
                };

                movementsDTOs.Add(movementsDTO);
            }

            return movementsDTOs;
        }

        public MovementsDTO MapperToDTO(Movements movements)
        {
            MovementsDTO movementsDTO = new MovementsDTO
            {
                Id = movements.Id,
                MovementType = movements.MovementType,
                Description = movements.Description,
                Observation = movements.Observation,
                Value = movements.Value,
                OperationDate = movements.OperationDate
            };

            return movementsDTO;
        }
        #endregion
    }
}