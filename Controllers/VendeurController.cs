using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using projetNet.Models;
using projetNet.Services.ServiceContracts;

namespace projetNet.Controllers
{
    [Authorize]
    public class VendeurController : Controller
    {
        private readonly IVehicleService _vehicleService;
        private readonly UserManager<ApplicationUser> _userManager;

        public VendeurController(
            IVehicleService vehicleService,
            UserManager<ApplicationUser> userManager)
        {
            _vehicleService = vehicleService;
            _userManager = userManager;
        }

        // GET: Vendeur
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var vehicles = await _vehicleService.GetByOwnerIdAsync(userId!);
            return View(vehicles);
        }

        // GET: Vendeur/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var vehicle = await _vehicleService.GetByIdAsync(id);
            if (vehicle == null) return NotFound();
            return View(vehicle);
        }

        // GET: Vendeur/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vendeur/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Vin,Brand,Model,Year,ImageUrl,Price,Description,Mileage,Location")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehicle.Id = Guid.NewGuid();
                vehicle.OwnerId = _userManager.GetUserId(User);
                vehicle.Status = "pending";
                await _vehicleService.CreateAsync(vehicle, vehicle.OwnerId!);
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: Vendeur/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var vehicle = await _vehicleService.GetByIdAsync(id);
            if (vehicle == null) return NotFound();
            return View(vehicle);
        }

        // POST: Vendeur/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Vin,Brand,Model,Year,ImageUrl,Price,Description,Mileage,Location")] Vehicle vehicle)
        {
            if (id != vehicle.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var existing = await _vehicleService.GetByIdAsync(id);
                if (existing == null) return NotFound();

                existing.Vin = vehicle.Vin;
                existing.Brand = vehicle.Brand;
                existing.Model = vehicle.Model;
                existing.Year = vehicle.Year;
                existing.ImageUrl = vehicle.ImageUrl;
                existing.Price = vehicle.Price;
                existing.Description = vehicle.Description;
                existing.Mileage = vehicle.Mileage;
                existing.Location = vehicle.Location;

                await _vehicleService.UpdateAsync(existing);
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: Vendeur/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var vehicle = await _vehicleService.GetByIdAsync(id);
            if (vehicle == null) return NotFound();
            return View(vehicle);
        }

        // POST: Vendeur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _vehicleService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
