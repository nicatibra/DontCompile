using CompileCrew.Models.Base;

namespace CompileCrew.Models
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<Employee> Employees { get; set; }





    }
}
