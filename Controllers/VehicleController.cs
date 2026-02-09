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
        private readonly IImageService _imageService;

        public VehicleController(ApplicationDbContext context,  IVehicleService vehicleService,
                                UserManager<ApplicationUser> userManager, IImageService imageService)
        {
            _context = context;
            _vehicleService = vehicleService;
            _userManager = userManager;
            _imageService = imageService;
            
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
        public async Task<IActionResult> Create( [Bind("Vin,Brand,Year,Model,Price,RentalPrice,Mileage,Location,Description")] Vehicle vehicle, IFormFile? imageFile)
        {
            var ownerId = _userManager.GetUserId(User);

            try
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    await using var stream = imageFile.OpenReadStream();
                    vehicle.ImageUrl = await _imageService.UploadImageAsync(
                        stream,
                        imageFile.FileName,
                        "vehicles"
                    );
                }

                await _vehicleService.CreateAsync(vehicle, ownerId);
                return RedirectToAction(nameof(UserVehicle));
            }
            catch (Exception ex)
            {
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
        public async Task<IActionResult> Edit(
            Guid id,
            [Bind("Vin,Brand,Year,Model,Price,RentalPrice,Mileage,Location,Description")] Vehicle vehicle,
            IFormFile? imageFile)
        {
            try
            {
                var existingVehicle = await _vehicleService.GetByIdAsync(id);
                if (existingVehicle == null)
                    return NotFound();

                existingVehicle.Vin = vehicle.Vin;
                existingVehicle.Brand = vehicle.Brand;
                existingVehicle.Year = vehicle.Year;
                existingVehicle.Model = vehicle.Model;
                existingVehicle.Price = vehicle.Price;
                existingVehicle.RentalPrice = vehicle.RentalPrice;
                
                existingVehicle.Mileage = vehicle.Mileage;
                existingVehicle.Location = vehicle.Location;
                existingVehicle.Description = vehicle.Description;

                if (imageFile != null && imageFile.Length > 0)
                {
                    // Optional: delete old image
                    if (!string.IsNullOrEmpty(existingVehicle.ImageUrl))
                    {
                        await _imageService.DeleteImageAsync(existingVehicle.ImageUrl);
                    }

                    await using var stream = imageFile.OpenReadStream();
                    existingVehicle.ImageUrl = await _imageService.UploadImageAsync(
                        stream,
                        imageFile.FileName,
                        "vehicles"
                    );
                }

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
