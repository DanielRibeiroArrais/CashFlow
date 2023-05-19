using CashFlow.Domain.Models;

namespace CashFlow.Application.DTO.DTO
{
    /// <summary>
    /// Consolidado dos movimentos
    /// </summary>
    public class ConsolidatedDTO : BaseDTO
    {
        public decimal Total { get; set; }
        public int OperationMonth { get; set; }
        public int OperationYear { get; set; }
    }
}
