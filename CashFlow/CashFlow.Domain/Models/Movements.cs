using CashFlow.Application.DTO.Enum;
using System.ComponentModel.DataAnnotations;

namespace CashFlow.Domain.Models
{
    public class Movements : Base
    {
        [Required]
        public EnumMovementType MovementType { get; private set; }

        [Required]
        [MaxLength(150)]
        public string Description { get; private set; }

        [MaxLength(500)]
        public string? Observation { get; private set; }

        [Required]
        public decimal Value { get; private set; }

        [Required]
        public DateTime OperationDate { get; private set; }

        public Movements(int id, EnumMovementType movementType, string description, string? observation, decimal value, DateTime operationDate)
        {
            Id = id;
            MovementType = movementType;
            Description = description;
            Observation = observation;
            Value = value;
            OperationDate = operationDate;
            ModificationDate = DateTime.Now;
        }
    }
}
