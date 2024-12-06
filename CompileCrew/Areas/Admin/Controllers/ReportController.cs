using CompileCrew.DAL;
using CompileCrew.Models;
using CompileCrew.ViewModels.Reports;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompileCrew.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,Moderator")]
    public class ReportController : Controller
    {
        private readonly AppDbContext _context;

        public ReportController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _context.Reports.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReportVM reportVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }



            Report report = new()
            {

                Type = reportVM.Type,
                Data = reportVM.Data,
                CreatedAt = DateTime.Now,
                SoftDelete = false
            };


            await _context.Reports.AddAsync(report);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) { return BadRequest(); }

            Report reportVM = await _context.Reports.FirstOrDefaultAsync(c => c.Id == id);

            if (reportVM == null) { return NotFound(); }

            UpdateReportVM categoryVM = new UpdateReportVM
            {
                Type = reportVM.Type,
                Data = reportVM.Data
            };

            return View(categoryVM);
        }

        public async Task<IActionResult> Update(UpdateReportVM reportVM)
        {
            if (reportVM == null)
            {
                throw new ArgumentNullException(nameof(reportVM));
            }
            var entity = await _context.Reports.FirstOrDefaultAsync(x => x.Id == reportVM.Id);
            if (entity == null)
            {
                return NotFound();
            }
            entity.Type = reportVM.Type;
            entity.Data = reportVM.Data;

            _context.Reports.Update(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Reports.FirstOrDefaultAsync(x => x.Id == id);
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
