using CompileCrew.Enums;
using CompileCrew.Models.Base;

namespace CompileCrew.Models
{
    public class Report : BaseEntity
    {



        public EReportsEnum Type { get; set; }

        public string Data { get; set; }
    }
}
