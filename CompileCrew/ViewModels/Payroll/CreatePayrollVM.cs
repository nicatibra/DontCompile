namespace CompileCrew.Areas.Admin.ViewModels
{
    public class CreatePayrollVM
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