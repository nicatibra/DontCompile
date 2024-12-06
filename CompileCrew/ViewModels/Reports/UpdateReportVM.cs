using CompileCrew.Enums;

namespace CompileCrew.ViewModels.Reports
{
    public class UpdateReportVM
    {
        public int Id { get; set; }

        public EReportsEnum Type { get; set; }

        public string Data { get; set; }
    }
}
