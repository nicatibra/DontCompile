namespace CompileCrew.ViewModels.ContractVM
{
    public class UpdateContractVM
    {
        public int ContractId { get; set; }

        public int EmployeeId { get; set; }


        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public decimal HourlyRate { get; set; }

        public int MonthlyMaxHours { get; set; }

        public decimal BonusPercentage { get; set; }
    }
}
