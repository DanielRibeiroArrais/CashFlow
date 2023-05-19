namespace CashFlow.Domain.Models
{
    public class Consolidated : Base
    {
        public Consolidated(int id, decimal total, int operationMonth, int operationYear)
        {
            Id = id;
            Total = total;
            OperationMonth = operationMonth;
            OperationYear = operationYear;
        }

        public decimal Total { get; set; }
        public int OperationMonth { get; set; }
        public int OperationYear { get; set; }
    }
}
