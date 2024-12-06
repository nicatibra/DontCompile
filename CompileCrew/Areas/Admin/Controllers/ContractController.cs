using CompileCrew.DAL;
using CompileCrew.Models;
using CompileCrew.ViewModels.ContractVM;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompileCrew.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin,Moderator")]

    public class ContractController : Controller
    {
        private readonly AppDbContext _context;

        public ContractController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            return View(await _context.Contracts.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContractVM contractVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }



            Contract contract = new()
            {

                EmployeeId = contractVM.EmployeeId,
                BonusPercentage = contractVM.BonusPercentage,
                StartTime = contractVM.StartTime,
                EndTime = contractVM.EndTime,
                HourlyRate = contractVM.HourlyRate,
                CreatedAt = DateTime.Now,
                SoftDelete = false
            };


            await _context.Contracts.AddAsync(contract);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) { return BadRequest(); }

            Contract contractVM = await _context.Contracts.FirstOrDefaultAsync(c => c.Id == id);

            if (contractVM == null) { return NotFound(); }

            UpdateContractVM categoryVM = new UpdateContractVM
            {
                EmployeeId = contractVM.EmployeeId,
                BonusPercentage = contractVM.BonusPercentage,
                StartTime = contractVM.StartTime,
                EndTime = contractVM.EndTime,
                HourlyRate = contractVM.HourlyRate
            };

            return View(categoryVM);
        }

        public async Task<IActionResult> Update(UpdateContractVM contractVM)
        {
            if (contractVM == null)
            {
                throw new ArgumentNullException(nameof(contractVM));
            }
            var entity = await _context.Contracts.FirstOrDefaultAsync(x => x.Id == contractVM.ContractId);
            if (entity == null)
            {
                return NotFound();
            }
            entity.EmployeeId = contractVM.EmployeeId;
            entity.Id = contractVM.ContractId;
            entity.StartTime = contractVM.StartTime;
            entity.EndTime = contractVM.EndTime;
            entity.HourlyRate = contractVM.HourlyRate;
            entity.MonthlyMaxHours = contractVM.MonthlyMaxHours;
            entity.BonusPercentage = contractVM.BonusPercentage;

            _context.Contracts.Update(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Contracts.FirstOrDefaultAsync(x => x.Id == id);
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
