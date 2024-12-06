using CompileCrew.Models.Base;

namespace CompileCrew.Models
{
    public class Contract : BaseEntity

    {
        public int EmployeeId { get; set; }

        public string Email { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public decimal HourlyRate { get; set; }

        public int MonthlyMaxHours { get; set; }

        public decimal BonusPercentage { get; set; }


    }
}
