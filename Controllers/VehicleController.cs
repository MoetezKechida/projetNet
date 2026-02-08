using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projetNet.Data;
using projetNet.Models;
using projetNet.Services.ServiceContracts;

namespace projetNet.Controllers
{
    
    public class VehicleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IVehicleService _vehicleService;
        private readonly UserManager<ApplicationUser> _userManager;

        public VehicleController(ApplicationDbContext context,  IVehicleService vehicleService, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _vehicleService = vehicleService;
            _userManager = userManager;
            
        }

        // GET: Vehicle
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vehicles.ToListAsync());
        }

        public async Task<IActionResult> UserVehicle()
        {
            var vehicles = await _vehicleService.GetByOwnerIdAsync(_userManager.GetUserId(User));
            return View(vehicles);
        }
        // GET: Vehicle/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var vehicle = await _vehicleService.GetByIdAsync(id);
            if (vehicle == null)
                return NotFound();

            return View(vehicle);
        }
        

        // GET: Vehicle/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Vehicle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Vin,Brand,Year")] Vehicle vehicle)
        {
            var ownerId = _userManager.GetUserId(User);
            try
            {
                var created = await _vehicleService.CreateAsync(vehicle, ownerId);

                // Redirect to Index action (list of vehicles)
                return RedirectToAction(nameof(UserVehicle));
            }
            catch (Exception ex)
            {
                // Return to the Create view with the model and error message
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(vehicle);
            }
        }


        // GET: Vehicle/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Vin,Brand,Year")] Vehicle vehicle)
        {
            try
            {
                var existingVehicle = await _vehicleService.GetByIdAsync(id);
                if (existingVehicle == null)
                    return NotFound();

                // Update only the properties you allow
                existingVehicle.Vin = vehicle.Vin;
                existingVehicle.Brand = vehicle.Brand;
                existingVehicle.Year = vehicle.Year;
                // OwnerId stays intact

                await _vehicleService.UpdateAsync(existingVehicle);
                return RedirectToAction(nameof(UserVehicle));

            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // GET: Vehicle/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(UserVehicle));
        }

        private bool VehicleExists(Guid id)
        {
            return _context.Vehicles.Any(e => e.Id == id);
        }
    }
}
