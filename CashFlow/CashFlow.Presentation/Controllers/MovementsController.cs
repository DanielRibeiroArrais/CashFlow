using CashFlow.Application.DTO.DTO;
using CashFlow.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Presentation.Controllers
{
    /// <summary>
    /// API para cadastro, consulta, atualização e exclusão dos movimentos
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MovementsController : ControllerBase
    {
        private readonly IApplicationServiceMovements _applicationServiceMovements;

        public MovementsController(IApplicationServiceMovements applicationServiceMovements)
        {
            _applicationServiceMovements = applicationServiceMovements;
        }

        /// <summary>
        /// Consulta um movimento pelo código
        /// </summary>
        /// <param name="id">Código do movimento</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MovementsDTO?>> GetByIdAsync([FromRoute] int id)
        {
            return await _applicationServiceMovements.GetByIdAsync(id);
        }

        /// <summary>
        /// Consulta todos os movimentos
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<ActionResult<List<MovementsDTO>>> GetAllAsync()
        {
            return Ok(await _applicationServiceMovements.GetAllAsync());
        }

        /// <summary>
        /// Cria um novo movimento
        /// </summary>
        /// <param name="movements"></param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task CreateAsync([FromBody] MovementsDTO movements)
        {
            await _applicationServiceMovements.CreateAsync(movements);
        }

        /// <summary>
        /// Atualiza um movimento existente pelo código
        /// </summary>
        /// <param name="id">Código do lançamento</param>
        /// <param name="movement"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task UpdateAsync([FromRoute] int id, [FromBody] MovementsDTO movement)
        {
            movement.Id = id;
            await _applicationServiceMovements.UpdateAsync(movement);
        }
    }
}
