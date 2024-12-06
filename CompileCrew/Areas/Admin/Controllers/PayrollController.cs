using CompileCrew.Areas.Admin.ViewModels;
using CompileCrew.DAL;
using CompileCrew.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompileCrew.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    public class PayrollController : Controller
    {
        private readonly AppDbContext _context;

        public PayrollController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _context.Payrolls.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePayrollVM PayrollVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }



            Payroll Payroll = new()
            {

                EmployeeId = PayrollVM.EmployeeId,
                Salary = PayrollVM.Salary,
                Bonus = PayrollVM.Bonus,
                Deductions = PayrollVM.Deductions,
                Month = PayrollVM.Month,
                Year = PayrollVM.Year,
                Status = false
            };


            await _context.Payrolls.AddAsync(Payroll);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) { return BadRequest(); }

            Payroll PayrollVM = await _context.Payrolls.FirstOrDefaultAsync(p => p.Id == id);

            if (PayrollVM == null) { return NotFound(); }

            UpdatePayrollVM payrollVM = new UpdatePayrollVM
            {
                Salary = PayrollVM.Salary,
                Bonus = PayrollVM.Bonus,
                Deductions = PayrollVM.Deductions,
                Month = PayrollVM.Month,
                Year = PayrollVM.Year,
                Status = false


            };

            return View(payrollVM);
        }

        public async Task<IActionResult> Update(UpdatePayrollVM PayrollVM)
        {
            if (PayrollVM == null)
            {
                throw new ArgumentNullException(nameof(PayrollVM));
            }
            var entity = await _context.Payrolls.FirstOrDefaultAsync(x => x.Id == PayrollVM.Id);
            if (entity == null)
            {
                return NotFound();
            }

            entity.Salary = PayrollVM.Salary;
            entity.Bonus = PayrollVM.Bonus;
            entity.Deductions = PayrollVM.Deductions;
            entity.Month = PayrollVM.Month;
            entity.Year = PayrollVM.Year;
            entity.Status = false;

            _context.Payrolls.Update(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Payrolls.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
