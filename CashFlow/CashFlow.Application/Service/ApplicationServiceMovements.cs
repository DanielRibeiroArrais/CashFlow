using CashFlow.Application.DTO.DTO;
using CashFlow.Application.Interfaces;
using CashFlow.Domain.Core.Interfaces.Services;
using CashFlow.Infrastructure.CrossCutting.Adapter.Interfaces;

namespace CashFlow.Application.Service
{
    public class ApplicationServiceMovements : IApplicationServiceMovements
    {
        private readonly IServiceMovements _serviceMovements;
        private readonly IMapperMovements _mapperMovements;

        public ApplicationServiceMovements(IServiceMovements serviceMovements, IMapperMovements mapperMovements)
        {
            _serviceMovements = serviceMovements;
            _mapperMovements = mapperMovements;
        }

        public async Task<MovementsDTO> CreateAsync(MovementsDTO movementsDTO)
        {
            return _mapperMovements.MapperToDTO(await _serviceMovements.CreateAsync(_mapperMovements.MapperToEntity(movementsDTO)));
        }

        public async Task<IEnumerable<MovementsDTO>> GetAllAsync()
        {
            return _mapperMovements.MapperListMovements(await _serviceMovements.GetAllAsync());
        }

        public async Task<MovementsDTO> GetByIdAsync(int id)
        {
            return _mapperMovements.MapperToDTO(await _serviceMovements.GetByIdAsync(id));
        }

        public async Task DeleteAsync(int id)
        {
            await _serviceMovements.DeleteAsync(await _serviceMovements.GetByIdAsync(id));
        }

        public async Task<MovementsDTO> UpdateAsync(MovementsDTO movementsDTO)
        {
            return _mapperMovements.MapperToDTO(await _serviceMovements.UpdateAsync(_mapperMovements.MapperToEntity(movementsDTO)));
        }
    }
}
