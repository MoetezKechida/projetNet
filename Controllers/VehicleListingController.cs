using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projetNet.Models;
using projetNet.Data;
using projetNet.DTOs.Common;
using System.Linq;

namespace projetNet.Controllers
{
    public class VehicleListingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehicleListingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /VehicleListing/
        public IActionResult Index()
        {
            var vehicles = _context.Vehicles.ToList();
            return View(vehicles);
        }

        // GET: /VehicleListing/Preview/5
        public async Task<IActionResult> Preview(Guid id)
        {
            var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            var viewModel = new VehiclePreviewViewModel
            {
                Vehicle = vehicle,
                HasSalePrice = vehicle.Price.HasValue && vehicle.Price.Value > 0,
                HasRentalPrice = vehicle.RentalPrice.HasValue && vehicle.RentalPrice.Value > 0
            };

            return View(viewModel);
        }
    }
}
