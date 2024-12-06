using CompileCrew.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CompileCrew.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<VacationRequest> VacationRequests { get; set; }


    }
}
