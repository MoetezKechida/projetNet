using Microsoft.AspNetCore.Mvc;
using projetNet.Models;
using projetNet.Data;
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
            var offers = _context.Offers
                .Where(o => o.Status == "accepted")
                .Select(o => new
                {
                    Offer = o,
                    Vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == o.VehicleId),
                    Seller = _context.Users.FirstOrDefault(u => u.Id == o.SellerId)
                })
                .ToList();

            return View(offers);
        }

        // GET: /VehicleListing/Preview/5
        public IActionResult Preview(Guid id)
        {
            var offer = _context.Offers.FirstOrDefault(o => o.VehicleId == id && o.Status == "accepted");
            if (offer == null)
            {
                return NotFound();
            }
            var vehicle = _context.Vehicles.FirstOrDefault(v => v.Id == offer.VehicleId);
            var seller = _context.Users.FirstOrDefault(u => u.Id == offer.SellerId);
            return View(new { Offer = offer, Vehicle = vehicle, Seller = seller });
        }

        [HttpPost]
        public IActionResult Rent(Guid VehicleId, string Name, string Email, int RentalDays)
        {
            // TODO: Save rent request to database or send email
            TempData["Message"] = $"Rent request submitted for {RentalDays} days by {Name}.";
            return RedirectToAction("Preview", new { id = VehicleId });
        }

        [HttpPost]
        public IActionResult Buy(Guid VehicleId, string Name, string Email, string Phone)
        {
            // TODO: Save buy request to database or send email
            TempData["Message"] = $"Buy request submitted by {Name}.";
            return RedirectToAction("Preview", new { id = VehicleId });
        }
    }
}
