using CompileCrew.Models.Base;

namespace CompileCrew.Models
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public decimal Salary { get; set; }

        public decimal Bonus { get; set; }

        public int ContractId { get; set; }

        public bool Attendance { get; set; }
    }
}
