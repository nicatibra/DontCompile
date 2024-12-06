using CompileCrew.DAL;
using CompileCrew.Models;
using CompileCrew.ViewModels.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompileCrew.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _context.Employees.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeVM employeeVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            bool result = await _context.Employees.AnyAsync(c => c.Name.Trim() == employeeVM.Name.Trim()); //Any() avtomatik ToLower edir

            if (result)
            {
                ModelState.AddModelError("Name", "Category already exists!");
                return View();
            }

            Employee employee = new()
            {

                Name = employeeVM.Name,
                Email = employeeVM.Password,
                Salary = employeeVM.Salary,
                Password = employeeVM.Password,
                Bonus = employeeVM.Bonus,
                ContractId = employeeVM.ContractId,
                CreatedAt = DateTime.Now,

            };


            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) { return BadRequest(); }

            Employee employee = await _context.Employees.FirstOrDefaultAsync(c => c.Id == id);

            if (employee == null) { return NotFound(); }

            UpdateEmployeeVM categoryVM = new UpdateEmployeeVM
            {
                Name = employee.Name,
                Email = employee.Password,
                Salary = employee.Salary,
                Bonus = employee.Bonus,
                ContractId = employee.ContractId,
                EmployeeId = employee.Id
            };

            return View(categoryVM);
        }

        public async Task<IActionResult> Update(UpdateEmployeeVM employeeVM)
        {
            if (employeeVM == null)
            {
                throw new ArgumentNullException(nameof(employeeVM));
            }
            var entity = await _context.Employees.FirstOrDefaultAsync(x => x.Id == employeeVM.EmployeeId);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Attendance = employeeVM.Attendance;
            entity.Email = employeeVM.Email;
            entity.Bonus = employeeVM.Bonus;
            entity.Salary = employeeVM.Salary;
            entity.ContractId = employeeVM.ContractId;
            entity.Name = employeeVM.Name;

            _context.Employees.Update(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
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