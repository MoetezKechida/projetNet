using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using projetNet.Data;
using projetNet.Helpers;
using projetNet.Models;
using projetNet.Services.ServiceContracts;

namespace projetNet.Controllers
{

    [Authorize]
    public class VendeurController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IVehicleService _vehicleService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IImageService _imageService;
        private readonly ILogger<VendeurController> _logger;
        private readonly IInspectionService _inspectionService;

        public VendeurController(ApplicationDbContext context, IVehicleService vehicleService,
            UserManager<ApplicationUser> userManager, IImageService imageService,
            ILogger<VendeurController> logger, IInspectionService inspectionService)
        {
            _context = context;
            _vehicleService = vehicleService;
            _userManager = userManager;
            _imageService = imageService;
            _logger = logger;
            _inspectionService = inspectionService;

        }

        // GET: Vehicle


        public async Task<IActionResult> UserVehicle(string status)
        {
            var ownerId = _userManager.GetUserId(User);

            IEnumerable<Vehicle> vehicles;

            if (string.IsNullOrEmpty(status))
            {
                vehicles = await _vehicleService.GetByOwnerIdAsync(ownerId);
            }
            else
            {
                vehicles = await _vehicleService.GetByStatusAndOwnerAsync(status, ownerId);
            }

            ViewBag.Statuses = new List<string> { "pending", "declined", "accepted" };
            ViewBag.SelectedStatus = status;

            return View(vehicles);
        }



        // GET: Vehicle/Create
        public IActionResult Create()
        {
            ViewBag.Brands = VehicleData.GetBrands();
            return View();
        }

        // POST: Vehicle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Vin,Brand,Year,Model,Price,RentalPrice,Mileage,Location,Description")]
            Vehicle vehicle,
            IFormFile? imageFile)
        {
            
                
            ViewBag.Brands = VehicleData.GetBrands();
            
            
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
            [Bind("Vin,Brand,Year,Model,Price,RentalPrice,Mileage,Location,Description")]
            Vehicle vehicle,
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
                existingVehicle.Status = "pending";
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




        public async Task<IActionResult> Reason(Guid id)
        {
            var inspections = await _inspectionService.GetByVehicleIdAsync(id);
            var inspection = inspections.FirstOrDefault();
            var vehicle = await _vehicleService.GetByIdAsync(id);
            ViewBag.inspection = inspection;
            ViewBag.vehicle = vehicle;
            return View();
        }


    }
}