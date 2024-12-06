using CompileCrew.Models.Base;

namespace CompileCrew.Models
{
    public class Payroll : BaseEntity
    {
        public int EmployeeId { get; set; }

        public decimal Salary { get; set; }

        public decimal Bonus { get; set; }

        public DateTime Deductions { get; set; } //siden cixma

        public DateTime Month { get; set; }

        public DateTime Year { get; set; }

        public bool Status { get; set; }

    }
}
