using CompileCrew.Models.Base;

namespace CompileCrew.Models
{
    public class VacationRequest : BaseEntity
    {
        public int EmployeeId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
        public bool Status { get; set; }

        public string Reason { get; set; }


    }
}
