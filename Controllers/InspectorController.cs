using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projetNet.Data;
using projetNet.Models;
using projetNet.Services.ServiceContracts;
using projetNet.Services.Services;

namespace projetNet.Controllers
{
    public class InspectorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IVehicleService _vehicleService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IInspectionService _inspectionService;
        public InspectorController(ApplicationDbContext context, IVehicleService vehicleService,
                                    UserManager<ApplicationUser> userManager,  IInspectionService inspectionService)
        {
            _context = context;
            _vehicleService = vehicleService;
            _userManager = userManager;
            _inspectionService = inspectionService;
        }

        // GET: Inspector
        public async Task<IActionResult> Index(string? brand)
        {
            ViewBag.Brands = await _vehicleService.GetDistinctBrandsAsync();

            if (string.IsNullOrEmpty(brand))
            {
                return View(await _vehicleService.GetByStatusAsync("pending"));
            }

            ViewBag.ChosenBrand = brand;
            return View(await _vehicleService.GetByStatusAndBrandAsync("pending", brand));
        }

        
        
        public async Task<IActionResult> Accept(Guid id)
        {
            
            var vehicle = await _vehicleService.GetByIdAsync(id);

            vehicle.Status = "accepted";

            await _vehicleService.UpdateAsync(vehicle);

            return View();
        }


        // GET: Inspector/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inspection = await _context.Inspections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inspection == null)
            {
                return NotFound();
            }

            return View(inspection);
        }

        // GET: Inspector/Create
        
        public IActionResult Create(Guid vehicleId)
        {
            
            var inspection = new Inspection
            {
                VehicleId = vehicleId
                
            };

            return View(inspection);
        }

        // POST: Inspector/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guid vehicleId, [Bind("Reason")] Inspection inspection)
        {   
            ModelState.Remove(nameof(inspection.Id));
            ModelState.Remove(nameof(inspection.InspectorId));
            if (!ModelState.IsValid)
            {
                // Return view if reason is missing
                inspection.VehicleId = vehicleId;
                return View(inspection);
            }

            // Call the service to create the inspection
            await _inspectionService.CreateAsync(
                vehicleId,
                _userManager.GetUserId(User), // InspectorId from logged-in user
                inspection.Reason
            );
            return RedirectToAction(nameof(Index));
        }

        // GET: Inspector/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inspection = await _context.Inspections.FindAsync(id);
            if (inspection == null)
            {
                return NotFound();
            }
            return View(inspection);
        }

        // POST: Inspector/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,VehicleId,InspectorId,Report")] Inspection inspection)
        {
            if (ModelState.IsValid)
            {
                inspection.Id = Guid.NewGuid();
                inspection.InspectorId = _userManager.GetUserId(User); // automatically fill InspectorId

                _context.Add(inspection);
                await _context.SaveChangesAsync();
                
            }
            
            return RedirectToAction(nameof(Index));
        }

        // GET: Inspector/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inspection = await _context.Inspections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inspection == null)
            {
                return NotFound();
            }

            return View(inspection);
        }

        // POST: Inspector/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var inspection = await _context.Inspections.FindAsync(id);
            if (inspection != null)
            {
                _context.Inspections.Remove(inspection);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InspectionExists(Guid id)
        {
            return _context.Inspections.Any(e => e.Id == id);
        }
    }
}
