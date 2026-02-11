using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using projetNet.Models;
using projetNet.Services.ServiceContracts;

namespace projetNet.Controllers
{
    [Authorize(Roles = "Inspector,Admin")]
    public class InspectorController : Controller
    {
        private readonly IInspectionService _inspectionService;
        private readonly IVehicleService _vehicleService;
        private readonly UserManager<ApplicationUser> _userManager;

        public InspectorController(
            IInspectionService inspectionService,
            IVehicleService vehicleService,
            UserManager<ApplicationUser> userManager)
        {
            _inspectionService = inspectionService;
            _vehicleService = vehicleService;
            _userManager = userManager;
        }

        // GET: Inspector
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            // Assuming inspectors want to see their inspections or all available for inspection?
            // The service has GetByInspectorIdAsync
            var inspections = await _inspectionService.GetByInspectorIdAsync(userId!);
            return View(inspections);
        }

        // GET: Inspector/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var inspection = await _inspectionService.GetByIdAsync(id);
            if (inspection == null) return NotFound();
            return View(inspection);
        }
        
        // GET: Inspector/Create
        public async Task<IActionResult> Create()
        {
             // Inspectors might want to create inspection for a specific vehicle
             // Passing vehicle list to view
            var vehicles = await _vehicleService.GetAllAsync(); // Needs filtering for uninspected cars ideally
            ViewData["VehicleId"] = new SelectList(vehicles, "Id", "Brand");
            return View();
        }

        // POST: Inspector/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleId,Reason")] Inspection inspection)
        {
             // Assuming Reason is actually the Report content or initial notes
             var userId = _userManager.GetUserId(User);
             
             // The IInspectionService.CreateAsync takes (vehicleId, inspectorId, reason)
             if (inspection.VehicleId != Guid.Empty)
             {
                 await _inspectionService.CreateAsync(inspection.VehicleId, userId!, inspection.Reason ?? "Initial inspection");
                 return RedirectToAction(nameof(Index));
             }
             
             // Reload vehicles if failed
             var vehicles = await _vehicleService.GetAllAsync();
             ViewData["VehicleId"] = new SelectList(vehicles, "Id", "Brand", inspection.VehicleId);
             return View(inspection);
        }
        
        // GET: Inspector/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var inspection = await _inspectionService.GetByIdAsync(id);
            if (inspection == null) return NotFound();
            
            var vehicles = await _vehicleService.GetAllAsync();
            ViewData["VehicleId"] = new SelectList(vehicles, "Id", "Brand", inspection.VehicleId);
            return View(inspection);
        }

        // POST: Inspector/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,VehicleId,InspectorId,Reason")] Inspection inspection)
        {
            if (id != inspection.Id) return NotFound();

            var existing = await _inspectionService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            // Only update allowed fields
            existing.Reason = inspection.Reason;
            // VehicleId and InspectorId usually shouldn't change on edit

            await _inspectionService.UpdateInspectionAsync(existing);
            return RedirectToAction(nameof(Index));
        }

        // GET: Inspector/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var inspection = await _inspectionService.GetByIdAsync(id);
            if (inspection == null) return NotFound();
            return View(inspection);
        }

        // POST: Inspector/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _inspectionService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Accept(Guid id)
        {
            // Verify vehicle exists
            var vehicle = await _vehicleService.GetByIdAsync(id);
            if (vehicle == null) return NotFound();

            // Business logic: 'Accepting' a vehicle might mean updating its status
            vehicle.Status = "accepted";
            await _vehicleService.UpdateAsync(vehicle);

            return RedirectToAction(nameof(Index));
        }
    }
}
