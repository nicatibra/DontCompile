namespace CompileCrew.ViewModels.Employees
{
    public class UpdateEmployeeVM
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }



        public decimal Salary { get; set; }

        public decimal Bonus { get; set; }

        public int ContractId { get; set; }

        public bool Attendance { get; set; }
    }
}
