using CompileCrew.DAL;
using CompileCrew.Models;
using CompileCrew.ViewModels.VacationRequestVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompileCrew.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    public class VacationRequestController : Controller
    {
        private readonly AppDbContext _context;

        public VacationRequestController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _context.VacationRequests.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(CreateVacationRequestVM requestVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }



            VacationRequest request = new()
            {

                EmployeeId = requestVM.EmployeeId,
                StartTime = requestVM.StartTime,
                EndTime = requestVM.EndTime,
                Reason = requestVM.Reason,
                CreatedAt = DateTime.Now,
                SoftDelete = false
            };


            await _context.VacationRequests.AddAsync(request);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) { return BadRequest(); }

            VacationRequest requestVM = await _context.VacationRequests.FirstOrDefaultAsync(c => c.Id == id);

            if (requestVM == null) { return NotFound(); }

            UpdateVacationRequestVM categoryVM = new UpdateVacationRequestVM
            {
                EmployeeId = requestVM.EmployeeId,
                StartTime = requestVM.StartTime,
                EndTime = requestVM.EndTime,
                Reason = requestVM.Reason
            };

            return View(categoryVM);
        }

        public async Task<IActionResult> Update(UpdateVacationRequestVM requestVM)
        {
            if (requestVM == null)
            {
                throw new ArgumentNullException(nameof(requestVM));
            }
            var entity = await _context.VacationRequests.FirstOrDefaultAsync(x => x.Id == requestVM.Id);
            if (entity == null)
            {
                return NotFound();
            }
            entity.EmployeeId = requestVM.EmployeeId;
            entity.StartTime = requestVM.StartTime;
            entity.EndTime = requestVM.EndTime;
            entity.Reason = requestVM.Reason;

            _context.VacationRequests.Update(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.VacationRequests.FirstOrDefaultAsync(x => x.Id == id);
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
