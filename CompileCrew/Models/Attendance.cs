using CompileCrew.Models.Base;

namespace CompileCrew.Models
{
    public class Attendance : BaseEntity
    {
        public int EmployeeId { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int TotalHours { get; set; }

        public int OverTimeHours { get; set; }
    }
}
