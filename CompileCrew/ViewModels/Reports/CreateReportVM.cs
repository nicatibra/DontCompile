using CompileCrew.Enums;

namespace CompileCrew.ViewModels.Reports
{
    public class CreateReportVM
    {
        public int CompanyId { get; set; }

        public EReportsEnum Type { get; set; }

        public string Data { get; set; }
    }
}
