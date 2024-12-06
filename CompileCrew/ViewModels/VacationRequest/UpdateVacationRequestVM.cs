namespace CompileCrew.ViewModels.VacationRequestVM
{
    public class UpdateVacationRequestVM
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
        public bool Status { get; set; }

        public string Reason { get; set; }

    }
}
