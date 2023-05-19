using CashFlow.Application.DTO.DTO;
using CashFlow.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Presentation.Controllers
{
    /// <summary>
    /// API para consulta dos consolidados
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ConsolidatedController : ControllerBase
    {
        private readonly ILogger<ConsolidatedController> _logger;
        private readonly IApplicationServiceConsolidated _applicationServiceConsolidated;

        public ConsolidatedController(ILogger<ConsolidatedController> log, IApplicationServiceConsolidated applicationServiceConsolidated)
        {
            _logger = log;
            _applicationServiceConsolidated = applicationServiceConsolidated;
        }

        /// <summary>
        /// Consulta todos os consolidados
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ConsolidatedDTO>>> GetAllAsync()
        {
            _logger.LogInformation($"Call ConsolidatedController.GetAllAsync");
            return Ok(await _applicationServiceConsolidated.GetAllAsync());
        }

        /// <summary>
        /// Consulta todos os consolidados por ano
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        [Route("{year:int:range(1900, 9999)}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsolidatedDTO>>> GetByYearAsync(int year)
        {
            _logger.LogInformation($"Call ConsolidatedController.GetByYearAsync => {year}");
            return Ok(await _applicationServiceConsolidated.GetByYearAsync(year));
        }


        /// <summary>
        /// Consulta consolidado por mês e ano
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [Route("{month:int:range(1,12)}/{year:int:range(1900, 9999)}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConsolidatedDTO>>> GetByMonthYearAsync(int month, int year)
        {
            _logger.LogInformation($"Call ConsolidatedController.GetByMonthYearAsync => {month} and {year}");
            return Ok(await _applicationServiceConsolidated.GetByMonthYearAsync(month, year));
        }
    }
}
