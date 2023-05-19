using CashFlow.Application.DTO.Enum;
using CashFlow.Domain.Models;

namespace CashFlow.Application.DTO.DTO
{
    /// <summary>
    /// Lançamento movimentos
    /// </summary>
    public class MovementsDTO : BaseDTO
    {
        public EnumMovementType MovementType { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? Observation { get; set; }
        public decimal Value { get; set; }
        public DateTime OperationDate { get; set; }
    }
}
